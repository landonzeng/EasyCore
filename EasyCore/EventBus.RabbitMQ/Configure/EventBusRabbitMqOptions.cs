using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace EasyCore.EventBus.RabbitMQ.Configure
{
    public class EventBusRabbitMqOptions : IOptions<EventBusRabbitMqOptions>
    {
        //ex.ams.test_customer_sign
        public string ExchangeName { get; set; } = "ex.easycore.event_bus";
        public string HostName { get; set; } = "localhost";
        public int Port { set; get; } = 5672;
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";
        public string QueueName { set; get; } = "qu.easycore.event_bus.queue";
        public string Type { get; set; } = ExchangeType.Topic;
        /// <summary>
        /// Qos限速,默认1
        /// </summary>
        public ushort PrefetchCount { set; get; } = 1;
        /// <summary>
        /// 重试策略,默认5
        /// </summary>
        public int RetryCount { set; get; } = 5;

        EventBusRabbitMqOptions IOptions<EventBusRabbitMqOptions>.Value => this;
    }
}
