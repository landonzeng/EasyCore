using EasyCore.EventBus.Abstractions;
using EasyCore.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Module;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventBusController : ControllerBase
    {
        //private readonly IEventBus _eventBus;
        //public EventBusController(IEventBus eventBus) {
        //    _eventBus = eventBus;
        //}
        //// GET: api/EventBus
        //[HttpGet]
        //public void Get()
        //{
        //    string json = "{\"id\":\"AMS-a4b3ec00fdfd4e528138a04c7ac0f24b\",\"from\":\"AMS\",\"to\":\"ERP\",\"timestamp\":20191107180831493,\"payload\":{\"companyId\":\"9\",\"data\":[{\"belongArea\":\"租赁五部\",\"belongAreaId\":\"10113\",\"belongShop\":\"金桥租赁一区\",\"belongShopId\":\"1011304\",\"belongShopdz\":\"兰城店租赁1组\",\"belongShopdzId\":\"10113040201\",\"contractNo\":\"JYWT-SH-0028471\",\"contractSignDate\":\"2018-03-11 00:00:00\",\"contractStatus\":\"已续约\",\"djlName\":\"王殿龙\",\"productName\":\"普通相寓(原状)\",\"qzjName\":\"孙小苏\",\"userName\":\"靳威\"}],\"seqId\":\"20191107\",\"systemCode\":\"AMS\"},\"signType\":\"WT\",\"signString\":null,\"version\":\"0.1\",\"expiration\":null}";

        //    var cus = json.ToObject<CustomerSignInfo>();

        //    _eventBus.Publish(new CustomerSignEvent(cus));

        //}

        //// GET: api/EventBus/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/EventBus
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/EventBus/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
