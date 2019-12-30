using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.EventBus;
using EasyCore.EventBus.Abstractions;
using EasyCore.Utilities;
using Microsoft.Extensions.Logging;

namespace WebApi.Module
{
    public class CustomerSignEventHandler : IIntegrationEventHandler<CustomerSignEvent>
    {
        private readonly ILogger<CustomerSignEventHandler> _logger;
        public CustomerSignEventHandler(ILogger<CustomerSignEventHandler> logger)
        {
            _logger = logger;
        }

        public Task<bool> Handle(CustomerSignEvent @event)
        {
            try
            {
                //throw new Exception("tetst");
                Console.WriteLine("\n日志消费:" + @event.ToJson()+"\n\n");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("日志消费:" + ex.Message);
               return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
