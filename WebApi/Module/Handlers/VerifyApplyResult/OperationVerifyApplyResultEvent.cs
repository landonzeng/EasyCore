using EasyCore.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Module
{
    public class OperationVerifyApplyResultEvent : IntegrationEvent
    {
        public OperationVerifyApplyResultEvent(VerifyApplyResult verifyApplyResult)
        {
            this.VerifyApplyResult = verifyApplyResult;
        }

        public VerifyApplyResult VerifyApplyResult { get; set; }
    }
}