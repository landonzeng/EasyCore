using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.DES;
using EasyCore.EventBus;
using EasyCore.EventBus.Abstractions;
using EasyCore.Utilities;
using Microsoft.Extensions.Logging;

namespace WebApi.Module
{
    public class HouseBackTempEventHandler : IIntegrationEventHandler<OperationHouseBackInfoEvent>
    {
        private readonly ILogger<HouseBackTempEventHandler> _logger;

        public HouseBackTempEventHandler(ILogger<HouseBackTempEventHandler> logger)
        {
            _logger = logger;
        }

        public Task<bool> Handle(OperationHouseBackInfoEvent @event)
        {
            try
            {
                Console.WriteLine("\n日志消费:" + @event.ToJson() + "\n\n");
                var json = DESHelper.Decrypt(@event.HouseBackupInfo.Data, "cbs_5i5j_2021");
                var model = json.ToObject<HouseBackupDto>();
                ;
                //throw new Exception("tetst");
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