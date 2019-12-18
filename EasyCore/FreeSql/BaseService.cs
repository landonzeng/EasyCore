using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EasyCore.FreeSql
{
    public class BaseService : IServiceKey
    {
        //public ILogger Logger { get; }

        public IRepositoryUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public BaseService(IServiceProvider service)//, ILogger logger)
        {
            //Logger = logger;
            UnitOfWork = service.GetRequiredService<IRepositoryUnitOfWork>();
            Mapper = service.GetRequiredService<IMapper>();
        }
    }
}
