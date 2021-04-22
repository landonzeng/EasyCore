using EasyCore.EventBus.Events;

namespace EasyCore.EventBus.Abstractions
{
    public interface IEventBus
    {
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="event"></param>
        void Publish(IntegrationEvent @event);

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="exchanges"></param>
        /// <param name="queues"></param>
        /// <param name="event"></param>
        void Publish(string exchanges, string queues, IntegrationEvent @event);

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="exchanges"></param>
        /// <param name="routingKey"></param>
        /// <param name="queues"></param>
        /// <param name="jsonData"></param>
        void Publish(string exchanges, string routingKey, string queues, string jsonData);

        /// <summary>
        /// 消息订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH"></typeparam>
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;

        /// <summary>
        /// 动态订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="routingKey"></param>
        void SubscribeDynamic<TH>(string routingKey)
            where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// 动态订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="routingKey"></param>
        /// <param name="exchangeName"></param>
        /// <param name="queueName"></param>
        void SubscribeDynamic<TH>(string routingKey, string exchangeName, string queueName)
            where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// 取消动态订阅
        /// </summary>
        /// <typeparam name="TH"></typeparam>
        /// <param name="eventName"></param>
        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        /// <summary>
        /// 启动所有订阅
        /// </summary>
        void StartSubscribe();
    }
}