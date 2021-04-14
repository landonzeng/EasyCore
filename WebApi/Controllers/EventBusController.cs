using EasyCore.DES;
using EasyCore.EventBus.Abstractions;
using EasyCore.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Module;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventBusController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public EventBusController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        // GET: api/EventBus
        [HttpGet]
        public void Get()
        {
            var model = new HouseBackupDto()
            {
                HouseId = "SHQPS000000001",
                District = DistrictEnumer.QingPu,
                CertificateNumber = "青1234123456",
                Trustor = "张三",
                Sex = 1,
                MobilePhone = "13712345678",
                CommissionStartDate = DateTime.Now,
                AreaName = "小区",
                IsLease = HireState.No,
                RoomTypeString = HouseModel.ThreeRoomTwoHall,
                Orientation = Orientation.Southeast,
                Decoration = Fitment.Roughcast,
                SalePrice = 450,
                BrokerPhoneNumber = "13712345678",
                BrokerUserCode = "123456",
                Reg_Id = "111111",
                PropertyBookColor = "绿色",
            };
            string json = model.ToJson();

            json = "{\"HouseBackupInfo\":{\"Data\":\"" + DESHelper.Encrypt(json, "123456") + "\"},\"Id\":1381476266631331840,\"CreationDate\":\"2021-04-12T16:45:23.2095475+08:00\"}";

            var cus = json.ToObject<HouseBackupInfo>();

            _eventBus.Publish(new OperationHouseBackInfoEvent(cus));
        }

        /// <summary>
        ///
        /// </summary>
        [HttpGet("pubsh")]
        public void pubsh()
        {
            var model = new VerifyApplyResultDto()
            {
                HouseId = "SHQPS000000001",
                CertificateNumber = "青1234123456",
                VerifyApplyNumber = "123456123456",
                ProcessStatus = "核验通过",
                Reason = "",
                VerificationTime = DateTime.Now,
                FilePath = "SHQPS000000001.jpg",
                Reg_Id = "111111"
            };
            string json = model.ToJson();

            json = "{\"Data\":\"" + DESHelper.Encrypt(json, "123456") + "\"}";
            var cus = json.ToObject<VerifyApplyResult>();

            _eventBus.Publish("ex.system.verifyapplyresult.dev", "qu.system.housebackup.othersystem.dev", new OperationVerifyApplyResultEvent(cus));
        }
    }
}