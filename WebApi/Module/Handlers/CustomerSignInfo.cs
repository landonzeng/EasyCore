using System.Collections.Generic;

namespace WebApi.Module
{
    public class CustomerSignInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 来自
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 发往
        /// </summary>
        public string to { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Payload payload { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string signType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signString { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expiration { get; set; }
    }

    public class Payload
    {
        /// <summary>
        /// 公司id
        /// </summary>
        public string companyId { get; set; }
        /// <summary>
        /// 业务数据集合
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 推送主键
        /// </summary>
        public string seqId { get; set; }
        /// <summary>
        /// 系统Code
        /// </summary>
        public string systemCode { get; set; }
    }

    public class DataItem
    {
        /// <summary>
        /// 战区
        /// </summary>
        public string belongArea { get; set; }
        /// <summary>
        /// 战区ID
        /// </summary>
        public string belongAreaId { get; set; }
        /// <summary>
        /// 分战区
        /// </summary>
        public string belongShop { get; set; }
        /// <summary>
        /// 分战区ID
        /// </summary>
        public string belongShopId { get; set; }
        /// <summary>
        /// 店组
        /// </summary>
        public string belongShopdz { get; set; }
        /// <summary>
        /// 店组ID
        /// </summary>
        public string belongShopdzId { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string contractNo { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>
        public string contractSignDate { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string contractStatus { get; set; }
        /// <summary>
        /// 店经理
        /// </summary>
        public string djlName { get; set; }
        /// <summary>
        /// 区总
        /// </summary>
        public string qzjName { get; set; }
        /// <summary>
        /// 成交人
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 合同打印时间
        /// </summary>
        public string printTime { get; set; }
        /// <summary>
        /// 合同审批流程
        /// </summary>
        public string contractFlow { get; set; }
    }
}
