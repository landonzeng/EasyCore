using EasyCore.Quartz.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCore.Quartz
{
    /// <summary>
    ///
    /// </summary>
    public interface IScheduleManage
    {
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task AddScheduleAsync(ScheduleInfo model);

        /// <summary>
        /// 更新任务状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task UpdateScheduleStatusAsync(ScheduleInfo model);

        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<ScheduleInfo> GetScheduleModelAsync(ScheduleInfo model);

        /// <summary>
        /// 获取所有的定时任务
        /// </summary>
        /// <returns></returns>
        public Task<List<ScheduleInfo>> GetAllScheduleListAsync();
    }
}