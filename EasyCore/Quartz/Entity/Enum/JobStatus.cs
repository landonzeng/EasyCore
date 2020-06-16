using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCore.Quartz.Entity.Enum
{
    public enum JobStatus
    {
        /// <summary>
        /// 已启用
        /// </summary>
        [Description("已启用")]
        IsEnabled = 0,

        /// <summary>
        /// 待运行
        /// </summary>
        [Description("待运行")]
        WaitingForRunning = 1,

        /// <summary>
        /// 执行中
        /// </summary>
        [Description("执行中")]
        Running = 2,

        /// <summary>
        /// 执行完成
        /// </summary>
        [Description("执行完成")]
        Completes = 3,

        /// <summary>
        /// 执行任务计划中
        /// </summary>
        [Description("执行任务计划中")]
        PerformPlanTask = 4,

        /// <summary>
        /// 已停止
        /// </summary>
        [Description("已停止")]
        End = 5,
    }
}