using EasyCore.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Module
{
    public class OperationHouseBackInfoEvent : IntegrationEvent
    {
        public OperationHouseBackInfoEvent(HouseBackupInfo houseBackupInfo)
        {
            this.HouseBackupInfo = houseBackupInfo;
        }

        public HouseBackupInfo HouseBackupInfo { get; set; }
    }
}