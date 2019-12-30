using EasyCore.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Module
{
    public class CustomerSignEvent : IntegrationEvent
    {
        public CustomerSignEvent(CustomerSignInfo customerSignInfo)
        {
            this.CustomerSignInfo = customerSignInfo;
        }

        public CustomerSignInfo CustomerSignInfo { get; set; }
    }
}
