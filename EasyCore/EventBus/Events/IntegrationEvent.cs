using System;
using Newtonsoft.Json;

namespace EasyCore.EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = SnowflakeId.Default().NextId();
            CreationDate = DateTime.Now;
        }
        [JsonConstructor]
        public IntegrationEvent(long id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }
        [JsonProperty]
        public long Id { get; private set; }
        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}
