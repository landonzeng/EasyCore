using EasyCore.Quartz.Entity;
using EasyCore.Quartz.Entity.Enum;
using EasyCore.Quartz.Models;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace EasyCore.Quartz
{
    /// <summary>
    /// 任务调度中心
    /// </summary>
    public class JobCenter
    {
        private readonly IScheduleManage _scheduleManage;

        public JobCenter(IScheduleManage scheduleManage)
        {
            _scheduleManage = scheduleManage;
        }

        /// <summary>
        /// 任务计划
        /// </summary>
        public static IScheduler scheduler = null;

        public static async Task<IScheduler> GetSchedulerAsync()
        {
            if (scheduler != null)
            {
                return scheduler;
            }
            else
            {
                ISchedulerFactory schedf = new StdSchedulerFactory();
                IScheduler sched = await schedf.GetScheduler();
                return sched;
            }
        }

        /// <summary>
        /// 添加任务计划//或者进程终止后的开启
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddScheduleJobAsync(ScheduleInfo m)
        {
            try
            {
                if (m != null)
                {
                    if (m.StarRunTime == null)
                    {
                        m.StarRunTime = DateTime.Now;
                    }
                    DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(m.StarRunTime, 1);
                    if (m.EndRunTime == null)
                    {
                        m.EndRunTime = DateTime.MaxValue.AddDays(-1);
                    }
                    DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(m.EndRunTime, 1);
                    scheduler = await GetSchedulerAsync();
                    IJobDetail job = JobBuilder.Create<HttpJob>()
                      .WithIdentity(m.JobName, m.JobGroup)
                      .Build();
                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                 .StartAt(starRunTime)
                                                 .EndAt(endRunTime)
                                                 .WithIdentity(m.JobName, m.JobGroup)
                                                 .WithCronSchedule(m.CromExpress)
                                                 .Build();
                    //将信息写入
                    await _scheduleManage.AddScheduleAsync(m);
                    await scheduler.ScheduleJob(job, trigger);
                    await scheduler.Start();
                    await StopScheduleJobAsync(m.JobGroup, m.JobName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //MyLogger.WriteError(ex, null);
                return false;
            }
        }

        /// <summary>
        /// 暂停指定任务计划
        /// </summary>
        /// <returns></returns>
        public async Task<string> StopScheduleJobAsync(string jobGroup, string jobName)
        {
            try
            {
                scheduler = await GetSchedulerAsync();
                //使任务暂停
                await scheduler.PauseJob(new JobKey(jobName, jobGroup));
                //更新数据库
                await _scheduleManage.UpdateScheduleStatusAsync(new ScheduleInfo() { JobName = jobName, JobGroup = jobGroup, RunStatus = (int)JobStatus.End });
                var status = new StatusViewModel()
                {
                    Status = 0,
                    Msg = "暂停任务计划成功",
                };

                return JsonConvert.SerializeObject(status);
            }
            catch (Exception ex)
            {
                //MyLogger.WriteError(ex, null);
                var status = new StatusViewModel()
                {
                    Status = -1,
                    Msg = "暂停任务计划失败",
                };
                return JsonConvert.SerializeObject(status);
            }
        }

        /// <summary>
        /// 恢复指定的任务计划**恢复的是暂停后的任务计划，如果是程序奔溃后 或者是进程杀死后的恢复，此方法无效
        /// </summary>
        /// <returns></returns>
        public async Task<string> RunScheduleJobAsync(string jobGroup, string jobName)
        {
            try
            {
                //获取model
                var sm = await _scheduleManage.GetScheduleModelAsync(new ScheduleInfo() { JobName = jobName, JobGroup = jobGroup });
                await AddScheduleJobAsync(sm);
                sm.RunStatus = (int)JobStatus.IsEnabled;
                //更新model
                await _scheduleManage.UpdateScheduleStatusAsync(sm);
                scheduler = await GetSchedulerAsync();
                //resumejob 恢复
                await scheduler.ResumeJob(new JobKey(jobName, jobGroup));

                var status = new StatusViewModel()
                {
                    Status = 0,
                    Msg = "开启任务计划成功",
                };
                return JsonConvert.SerializeObject(status);
            }
            catch (Exception ex)
            {
                var status = new StatusViewModel()
                {
                    Status = -1,
                    Msg = "开启任务计划失败",
                };
                return JsonConvert.SerializeObject(status);
            }
        }
    }
}