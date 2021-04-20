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
        private readonly IEventBus _eventBus;

        public HouseBackTempEventHandler(ILogger<HouseBackTempEventHandler> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(OperationHouseBackInfoEvent @event)
        {
            try
            {
                Console.WriteLine("\n日志消费:" + @event.ToJson() + "\n\n");
                var json = DESHelper.Decrypt(@event.HouseBackupInfo.Data, "cbs_5i5j_2021");
                var model = json.ToObject<HouseBackupDto>();
                ;

                var VerifyRes = new VerifyApplyResultDto()
                {
                    HouseId = model.HouseId,
                    CertificateNumber = model.CertificateNumber,
                    VerifyApplyNumber = "123456123456",
                    ProcessStatus = "核验通过",
                    Reason = "",
                    VerificationTime = DateTime.Now,
                    FilePath = "SHPTS000068153.jpg",
                    Reg_Id = "111111"
                };
                json = VerifyRes.ToJson();

                var encryptString = DESHelper.Encrypt(json, "cbs_5i5j_2021");

                var res = new VerifyApplyResult()
                {
                    Data = encryptString
                };

                _eventBus.Publish("ex.gims.verifyapplyresult.dev", nameof(OperationVerifyApplyResultEvent), "qu.gims.verifyapplyresult.vplues.dev", res.ToJson());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //var json = "{\"AreaName\":\"测试小区\",\"CertificateNumber\":\"132565475654333\",\"CommissionStartDate\":\"2021-04-19\",\"HouseId\":\"237598322\",\"MobilePhone\":\"13898765432\",\"SalePrice\":0,\"Sex\":0,\"Trustor\":\"测试\",\"areaName\":\"测试小区\",\"certificateNumber\":\"132565475654333\",\"commissionStartDate\":\"2021-04-19\",\"houseId\":\"237598322\",\"mobilePhone\":\"13898765432\",\"salePrice\":0,\"sex\":0,\"trustor\":\"测试\"}";

                var backupInfo = new HouseBackupInfo();
                var ecStr = DESHelper.Encrypt(json, "cbs_5i5j_2021");
                backupInfo.Data = ecStr;

                var res = new OperationHouseBackInfoEvent(backupInfo);
                var re_json = res.ToJson();
                _eventBus.Publish("ex.vplues.housebackup.dev", nameof(OperationHouseBackInfoEvent), "qu.vplues.housebackup.gims.dev", re_json);
            }

            return await Task.FromResult(true);
        }
    }
}