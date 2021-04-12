using FreeSql.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Module
{
    /// <summary>
    /// 房源备案核验
    /// </summary>
    public class HouseBackupDto
    {
        /// <summary>
        /// V+房源唯一标识
        /// </summary>
        public string HouseId { get; set; }

        /// <summary>
        /// 行政区
        /// </summary>
        public DistrictEnumer District { get; set; }

        /// <summary>
        /// 产证编号
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 委托人
        /// </summary>
        public string Trustor { get; set; }

        /// <summary>
        /// 性别 [0 女，1 男]
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 委托开始日
        /// </summary>
        public DateTime CommissionStartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 小区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 有无租赁 [1有, 2无]
        /// </summary>
        public HireState IsLease { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public HouseModel RoomTypeString { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        public Orientation Orientation { get; set; } = Orientation.Unknown;

        /// <summary>
        /// 装修程度
        /// </summary>
        public Fitment Decoration { get; set; }

        /// <summary>
        /// 拟售价格(万元)
        /// </summary>
        public double SalePrice { get; set; }

        /// <summary>
        /// 经纪人工号
        /// </summary>
        public string BrokerUserCode { get; set; }

        /// <summary>
        /// 经纪人联系电话
        /// </summary>
        public string BrokerPhoneNumber { get; set; }

        /// <summary>
        /// V+待备案主键
        /// </summary>
        public string Reg_Id { get; set; }

        /// <summary>
        /// 产证颜色
        /// </summary>
        [MaxLength(50)]
        public string PropertyBookColor { get; set; }
    }
}