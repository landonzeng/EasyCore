using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.Entity;

namespace WebApi.Module
{
    public class LR_Test : EntityBase<int>
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string F_TestId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string F_EnCode { get; set; }
    }
}
