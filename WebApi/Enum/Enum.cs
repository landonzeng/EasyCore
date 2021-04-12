using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApi.Module
{
    /// <summary>
    /// 行政区枚举
    /// </summary>
    public enum DistrictEnumer
    {
        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        City = 0,

        /// <summary>
        /// 黄浦区
        /// </summary>
        [Description("黄浦区")]
        HuangPu = 1,

        /// <summary>
        /// 卢湾区
        /// </summary>
        [Description("卢湾区")]
        LuWang = 3,

        /// <summary>
        /// 徐汇区
        /// </summary>
        [Description("徐汇区")]
        XuHui = 4,

        /// <summary>
        /// 长宁区
        /// </summary>
        [Description("长宁区")]
        ChangNi = 5,

        /// <summary>
        /// 静安区
        /// </summary>
        [Description("静安区")]
        JingAN = 6,

        /// <summary>
        /// 普陀区
        /// </summary>
        [Description("普陀区")]
        PuTuo = 7,

        /// <summary>
        /// 闸北区
        /// </summary>
        [Description("闸北区")]
        ZhaBei = 8,

        /// <summary>
        /// 虹口区
        /// </summary>
        [Description("虹口区")]
        HongKou = 9,

        /// <summary>
        /// 杨浦区
        /// </summary>
        [Description("杨浦区")]
        YangPu = 10,

        /// <summary>
        /// 宝山区
        /// </summary>
        [Description("宝山区")]
        BaoShan = 11,

        /// <summary>
        /// 闵行区
        /// </summary>
        [Description("闵行区")]
        MinHang = 12,

        /// <summary>
        /// 嘉定区
        /// </summary>
        [Description("嘉定区")]
        JiaDing = 13,

        /// <summary>
        /// 浦东新区
        /// </summary>
        [Description("浦东新区")]
        PuDong = 14,

        /// <summary>
        /// 南汇区
        /// </summary>
        [Description("南汇区")]
        NanHui = 15,

        /// <summary>
        /// 奉贤区
        /// </summary>
        [Description("奉贤区")]
        FengXian = 16,

        /// <summary>
        /// 松江区
        /// </summary>
        [Description("松江区")]
        SongJiang = 17,

        /// <summary>
        /// 金山区
        /// </summary>
        [Description("金山区")]
        JinShan = 18,

        /// <summary>
        /// 青浦区
        /// </summary>
        [Description("青浦区")]
        QingPu = 19,

        /// <summary>
        /// 崇明区
        /// </summary>
        [Description("崇明区")]
        ChongMing = 20,

        /// <summary>
        /// 农场局
        /// </summary>
        [Description("农场局")]
        NonChanJu = 22
    }

    /// <summary>
    /// 房型
    /// </summary>
    public enum HouseModel
    {
        /// <summary>
        /// 一室
        /// </summary>
        [Description("一室")]
        OneRoom = 1,

        /// <summary>
        /// 一室半
        /// </summary>
        [Description("一室半")]
        OneHalfRoom = 2,

        /// <summary>
        /// 一室一厅
        /// </summary>
        [Description("一室一厅")]
        OneRoomOneHall = 3,

        /// <summary>
        /// 二室
        /// </summary>
        [Description("二室")]
        TwoRoom = 4,

        /// <summary>
        /// 二室半
        /// </summary>
        [Description("二室半")]
        TwoHalfRoom = 5,

        /// <summary>
        /// 二室一厅
        /// </summary>
        [Description("二室一厅")]
        TwoRoomOneHall = 6,

        /// <summary>
        /// 二室二厅
        /// </summary>
        [Description("二室二厅")]
        TwoRoomTwoHall = 7,

        /// <summary>
        /// 三室
        /// </summary>
        [Description("三室")]
        ThreeRoom = 8,

        /// <summary>
        /// 三室一厅
        /// </summary>
        [Description("三室一厅")]
        ThreeRoomOneHall = 9,

        /// <summary>
        /// 三室二厅
        /// </summary>
        [Description("三室二厅")]
        ThreeRoomTwoHall = 10,

        /// <summary>
        /// 四室
        /// </summary>
        [Description("四室")]
        FourRoom = 11,

        /// <summary>
        /// 四室一厅
        /// </summary>
        [Description("四室一厅")]
        FourRoomOneHall = 12,

        /// <summary>
        /// 四室二厅
        /// </summary>
        [Description("四室二厅")]
        FourRoomTwoHall = 13,

        /// <summary>
        /// 五室二厅
        /// </summary>
        [Description("五室二厅")]
        FiveRoomTwoHall = 14,

        /// <summary>
        /// 五室三厅
        /// </summary>
        [Description("五室三厅")]
        FiveRoomThreeHall = 15,

        /// <summary>
        /// 开间
        /// </summary>
        [Description("开间")]
        OpenRoom = 16,

        /// <summary>
        /// 复式
        /// </summary>
        [Description("复式")]
        Duplex = 18,

        /// <summary>
        /// 一室两厅
        /// </summary>
        [Description("一室两厅")]
        OneRoomTwoHall = 19,

        /// <summary>
        /// 一室三厅
        /// </summary>
        [Description("一室三厅")]
        OneRoomThreeHall = 20,

        /// <summary>
        /// 二室三厅
        /// </summary>
        [Description("二室三厅")]
        TwoRoomThreeHall = 21,

        /// <summary>
        /// 三室三厅
        /// </summary>
        [Description("三室三厅")]
        ThreeRoomThreeHall = 22,

        /// <summary>
        /// 四室三厅
        /// </summary>
        [Description("四室三厅")]
        FourRoomThreeHall = 23,

        /// <summary>
        /// 独立别墅
        /// </summary>
        [Description("独立别墅")]
        DetachedHouse = 24,

        /// <summary>
        /// 联体别墅
        /// </summary>
        [Description("联体别墅")]
        TownHouses = 25,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 26,

        /// <summary>
        /// 不成套
        /// </summary>
        [Description("不成套")]
        Incomplete = 31
    }

    /// <summary>
    /// 朝向
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// 南
        /// </summary>
        [Description("南")]
        South = 1,

        /// <summary>
        /// 东南
        /// </summary>
        [Description("东南")]
        Southeast = 2,

        /// <summary>
        /// 西南
        /// </summary>
        [Description("西南")]
        Southwest = 3,

        /// <summary>
        /// 北
        /// </summary>
        [Description("北")]
        North = 4,

        /// <summary>
        /// 东北
        /// </summary>
        [Description("东北")]
        Northeast = 5,

        /// <summary>
        /// 西北
        /// </summary>
        [Description("西北")]
        Northwest = 6,

        /// <summary>
        /// 东
        /// </summary>
        [Description("东")]
        East = 7,

        /// <summary>
        /// 西
        /// </summary>
        [Description("西")]
        West = 8,

        /// <summary>
        /// 不明
        /// </summary>
        [Description("不明")]
        Unknown = 9
    }

    /// <summary>
    /// 装修程度
    /// </summary>
    public enum Fitment
    {
        /// <summary>
        /// 毛坯
        /// </summary>
        [Description("毛坯")]
        Roughcast = 1,

        /// <summary>
        /// 简装
        /// </summary>
        [Description("简装")]
        Simplex = 2,

        /// <summary>
        /// 精装
        /// </summary>
        [Description("精装")]
        Hardcover = 3
    }

    /// <summary>
    /// 租赁状况
    /// </summary>
    public enum HireState
    {
        /// <summary>
        /// 有
        /// </summary>
        [Description("有")]
        Yes = 1,

        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        No = 2
    }

    /// <summary>
    /// 房屋装饰(设备)处理
    /// </summary>
    public enum Decorate
    {
        /// <summary>
        /// 作价
        /// </summary>
        [Description("作价")]
        CalculatePrice = 1,

        /// <summary>
        /// 不作价
        /// </summary>
        [Description("不作价")]
        NoCalculatePrice = 2
    }

    /// <summary>
    /// 维修基金结算方式
    /// </summary>
    public enum BalanceMode
    {
        /// <summary>
        /// 赠送
        /// </summary>
        [Description("赠送")]
        Gift = 1,

        /// <summary>
        /// 不赠送
        /// </summary>
        [Description("不赠送")]
        NoGifts = 2
    }

    /// <summary>
    /// 抵押状况
    /// </summary>
    public enum MortState
    {
        ///// <summary>
        ///// 有
        ///// </summary>
        //[Description("有")]
        //Yes = 1,

        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        No = 2
    }
}