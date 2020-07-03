using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EasyCore.EventBus.Abstractions;
using EasyCore.EventBus.Attributes;
using EasyCore.EventBus.Events;
using EasyCore.EventBus.RabbitMQ.Configure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace EasyCore.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private readonly string _exchangeName = "ex.easycore.event_bus";

        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQ> _logger;
        private readonly IEventBusSubscriptionsManager _subsManager;
        private readonly IServiceProvider _autofac;
        private readonly EventBusRabbitMqOptions _options;
        private readonly int _retryCount;
        private readonly ushort _prefetchCount;

        private IDictionary<string, IModel> _consumerChannels;
        private readonly string _queueName;
        private readonly string _type;

        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQ> logger, IServiceProvider autofac,
            IEventBusSubscriptionsManager subsManager, IOptions<EventBusRabbitMqOptions> options)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _subsManager = subsManager ?? throw new ArgumentNullException(nameof(subsManager));
            _options = options.Value;
            _exchangeName = _options.ExchangeName;
            _queueName = _options.QueueName;
            _type = _options.Type;
            _consumerChannels = new Dictionary<string, IModel>();
            _autofac = autofac;
            _prefetchCount = _options.PrefetchCount;
            _retryCount = _options.RetryCount;
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        #region 推送

        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="event"></param>
        public void Publish(IntegrationEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    // 防止logging走事件
                    // _logger.LogWarning(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", @event.Id, $"{time.TotalSeconds:n1}", ex.Message);
                    Console.WriteLine($"Could not publish event: {@event.Id} after {time.TotalSeconds:n1}s ({ex.Message})");
                });

            var eventName = @event.GetType().Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            using (var channel = _persistentConnection.CreateModel())
            {
                //durable：持久化存储队列

                //autoDelete：自动删除，如果该队列没有任何订阅的消费者的话，该队列会被自动删除。这种队列适用于临时队列。

                //exclusive：排他队列，如果一个队列被声明为排他队列，该队列仅对首次声明它的连接可见，并在连接断开时自动删除。
                //注意事项：1，排他队列是基于连接可见的，同一连接的不同信道是可以同时访问同一个连接创建的排他队列的。
                //          2，"首次"，如果一个连接已经声明了一个排他队列，其他连接是不允许建立同名的排他队列的，这个与普通队列不同。
                //          3，即使该队列是持久化的，一旦连接关闭或者客户端退出，该排他队列都会被自动删除的。这种队列适用于只限于一个客户端发送读取消息的应用场景。

                //交换机持久化
                channel.ExchangeDeclare(exchange: _exchangeName, type: _type, durable: true);

                //队列持久化
                channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, null);
                channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: eventName, arguments: null);

                policy.Execute(() =>
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2; //消息的投递模式，默认为1 非持久化的，2 持久化存储消息内容

                    channel.BasicPublish(exchange: _exchangeName, routingKey: eventName, mandatory: true, basicProperties: properties, body: body);
                });
            }
        }

        #endregion 推送

        #region 订阅注册

        /// <summary>
        /// 订阅注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subsManager.GetEventKey<T>();
            var queueName = GetQueueName<TH>();

            DoInternalSubscription(eventName, queueName);

            _subsManager.AddSubscription<T, TH>();
        }

        private void DoInternalSubscription(string eventName, string queueName)
        {
            var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
            if (!containsKey)
            {
                if (!_persistentConnection.IsConnected)
                {
                    _persistentConnection.TryConnect();
                }

                if (!_consumerChannels.ContainsKey(queueName))
                {
                    _consumerChannels.Add(queueName, CreateConsumerChannel(queueName));
                }

                using (var channel = _persistentConnection.CreateModel())
                {
                    channel.QueueBind(queue: queueName, exchange: _exchangeName, routingKey: eventName, arguments: null);
                }
            }
        }

        /// <summary>
        /// 创建消费监听
        /// </summary>
        /// <returns></returns>
        private IModel CreateConsumerChannel(string queueName)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(exchange: _exchangeName, type: _type, durable: true, autoDelete: false, arguments: null);

            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.BasicQos(0, _prefetchCount, false);

            channel.CallbackException += (sender, ea) =>
            {
                channel.Dispose();
                channel = CreateConsumerChannel(queueName);
            };

            return channel;
        }

        #endregion 订阅注册

        #region 取消订阅

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        public void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        #endregion 取消订阅

        #region 释放

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            foreach (var key in _consumerChannels.Keys)
            {
                if (_consumerChannels.TryGetValue(key, out var _consumerChannel) && _consumerChannel != null)
                {
                    _consumerChannel.Dispose();
                }
            }
            _subsManager.Clear();
        }

        #endregion 释放

        #region RabbitMQ取消订阅

        /// <summary>
        /// RabbitMQ取消订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventName"></param>
        private void SubsManager_OnEventRemoved(object sender, string eventName)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                foreach (var queueName in _consumerChannels.Keys)
                {
                    channel.QueueUnbind(queue: queueName,
                                        exchange: _exchangeName,
                                        routingKey: eventName);
                }
            }
        }

        #endregion RabbitMQ取消订阅

        #region 订阅启动

        /// <summary>
        /// 订阅启动
        /// </summary>
        public void StartSubscribe()
        {
            foreach (var queueName in _consumerChannels.Keys)
            {
                _consumerChannels.TryGetValue(queueName, out var _consumerChannel);

                if (_consumerChannel == null || _consumerChannel.IsClosed)
                    _consumerChannel = CreateConsumerChannel(queueName);

                var consumer = new AsyncEventingBasicConsumer(_consumerChannel);

                consumer.Received += async (model, ea) =>
                {
                    var eventName = ea.RoutingKey;
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    if (message.Length > 0)
                    {
                        var result = await ProcessEvent(eventName, message);
                        if (result)
                        {
                            _consumerChannel.BasicAck(ea.DeliveryTag, multiple: false);
                        }
                        else {
                            _consumerChannel.BasicAck(ea.DeliveryTag, multiple: true);
                        }
                    }
                };

                _consumerChannel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
            }
        }

        /// <summary>
        /// 执行器
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task<bool> ProcessEvent(string eventName, string message)
        {
            if (_subsManager.HasSubscriptionsForEvent(eventName))
            {
                using (var scope = _autofac.CreateScope())
                {
                    var subscriptions = _subsManager.GetHandlersForEvent(eventName);
                    foreach (var subscription in subscriptions)
                    {
                        if (subscription.IsDynamic)
                        {
                            if (!(scope.ServiceProvider.GetRequiredService(subscription.HandlerType) is IDynamicIntegrationEventHandler handler)) continue;

                            await Task.Yield();
                            await handler.Handle(message);
                            return true;
                        }
                        else
                        {
                            var eventType = _subsManager.GetEventTypeByName(eventName);
                            if (eventType == null) continue;
                            var handler = scope.ServiceProvider.GetRequiredService(subscription.HandlerType);
                            if (handler == null) continue;
                            var integrationEvent = new object();
                            try
                            {
                                integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);

                            await Task.Yield();
                            return await (Task<bool>)concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                        }
                    }
                }
            }
            return true;
        }

        #endregion 订阅启动

        /// <summary>
        /// 动态内容订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler
        {
            var queueName = GetQueueName<TH>();

            DoInternalSubscription(eventName, queueName);

            _subsManager.AddDynamicSubscription<TH>(eventName);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        public void UnsubscribeDynamic<TH>(string eventName)
           where TH : IDynamicIntegrationEventHandler
        {
            _subsManager.RemoveDynamicSubscription<TH>(eventName);
        }

        /// <summary>
        /// 获取QueueName
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <returns></returns>
        private string GetQueueName<TH>()
        {
            var queueName = _queueName;
            var queueConsumerAttr = typeof(TH).GetCustomAttribute<QueueConsumerAttribute>();
            if (queueConsumerAttr != null)
            {
                queueName = queueConsumerAttr.QueueName;
            }
            return queueName;
        }
    }
}