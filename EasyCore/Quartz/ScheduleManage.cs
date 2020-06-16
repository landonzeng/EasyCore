using EasyCore.Quartz.DbContext;
using EasyCore.Quartz.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.Formula.Functions;
using System.Threading.Tasks;

namespace EasyCore.Quartz
{
    public class ScheduleManage : IScheduleManage
    {
        private readonly IFreeSql<IQuartzDB> _freeSql;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service"></param>
        public ScheduleManage(IServiceProvider service)
        {
            _freeSql = service.GetService<IFreeSql<IQuartzDB>>();
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="model"></param>
        public async Task AddScheduleAsync(ScheduleInfo model)
        {
            var info = await _freeSql.Select<ScheduleInfo>().Where(t => t.Id == model.Id || (t.JobGroup == model.JobGroup && t.JobName == model.JobName)).FirstAsync();
            if (info == null)
            {
                await _freeSql.Insert(model).ExecuteAffrowsAsync();
            }
        }

        /// <summary>
        /// 更新任务状态
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateScheduleStatusAsync(ScheduleInfo model)
        {
            var info = await _freeSql.Select<ScheduleInfo>().Where(t => t.JobName == model.JobName && t.JobGroup == model.JobGroup).FirstAsync();
            if (info != null)
            {
                info.RunStatus = model.RunStatus;
            }

            await _freeSql.Update<ScheduleInfo>().SetSource(info).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ScheduleInfo> GetScheduleModelAsync(ScheduleInfo model)
        {
            var info = await _freeSql.Select<ScheduleInfo>().Where(t => t.JobGroup == model.JobGroup && t.JobName == model.JobName).FirstAsync();
            return info;
        }

        /// <summary>
        /// 获取所有的定时任务
        /// </summary>
        /// <returns></returns>
        public async Task<List<ScheduleInfo>> GetAllScheduleListAsync()
        {
            var info = await _freeSql.Select<ScheduleInfo>().ToListAsync();
            return info;
        }
    }
}