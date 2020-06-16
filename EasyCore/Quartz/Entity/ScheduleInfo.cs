using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCore.Quartz.Entity
{
    /// <summary>
    /// 任务表
    /// </summary>
    [Table(Name = "T_ScheduleInfo")]
    public partial class ScheduleInfo
    {
        [Column(IsPrimary = true, IsIdentity = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 任务组
        /// </summary>
        [DisplayName("任务组")]
        [Column(DbType = "nvarchar(200)")]
        public string JobGroup { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        [DisplayName("任务名")]
        [Column(DbType = "nvarchar(200)")]
        public string JobName { get; set; }

        /// <summary>
        /// 运行状态
        /// </summary>
        [DisplayName("运行状态")]
        public int RunStatus { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        [DisplayName("Cron表达式")]
        [Column(DbType = "nvarchar(200)")]
        public string CromExpress { get; set; }

        /// <summary>
        /// 开始运行时间
        /// </summary>
        [DisplayName("开始运行时间")]
        [Column(DbType = "varchar(200)")]
        public DateTime? StarRunTime { get; set; }

        /// <summary>
        /// 结束运行时间
        /// </summary>
        [DisplayName("结束运行时间")]
        [Column(DbType = "varchar(200)")]
        public DateTime? EndRunTime { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        [DisplayName("下次运行时间")]
        [Column(DbType = "varchar(200)")]
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [DisplayName("Token")]
        [Column(DbType = "nvarchar(50)")]
        public string Token { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        [DisplayName("AppId")]
        [Column(DbType = "nvarchar(50)")]
        public string AppId { get; set; }

        /// <summary>
        /// ServiceCode
        /// </summary>
        [DisplayName("ServiceCode")]
        [Column(DbType = "nvarchar(50)")]
        public string ServiceCode { get; set; }

        /// <summary>
        /// InterfaceCode
        /// </summary>
        [DisplayName("InterfaceCode")]
        [Column(DbType = "nvarchar(50)")]
        public string InterfaceCode { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        [DisplayName("任务描述")]
        [Column(DbType = "nvarchar(200)")]
        public string TaskDescription { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        [DisplayName("数据状态")]
        public int? DataStatus { get; set; }

        /// <summary>
        /// 任务添加者
        /// </summary>
        [DisplayName("任务添加者")]
        [Column(DbType = "nvarchar(50)")]
        public string CreateAuthr { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}