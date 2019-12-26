using System;
using System.Collections.Generic;
using System.Text;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Util.Helpers;

namespace EasyCore.FreeSql.UseUnitOfWork
{
    public class UnitOfWork<Context> : UnitOfWork, IUnitOfWork<Context>
    {
        private IServiceProvider _serviceProvider;
        /// <summary>
        /// 追踪号
        /// </summary>
        public UnitOfWork(IServiceProvider service) : base(service.GetRequiredService<IFreeSql<Context>>())
        {
            _serviceProvider = service ?? Ioc.Create<IServiceProvider>();
            Create<IFreeSqlUnitOfWorkManager>().Register(this);
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        private T Create<T>()
        {
            var result = _serviceProvider.GetService<T>();
            if (result == null)
            {
                return default(T);
            }
            else
            {
                return result;
            }
        }
    }
}
