using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCore.Quartz
{
    public class HttpJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //更具任务组执行具体的任务
            //MyLogger.WriteMessage("gogogo");
            await Console.Out.WriteLineAsync("Greetings from HelloJob!");
        }
    }
}