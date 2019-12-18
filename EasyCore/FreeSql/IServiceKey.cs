using FreeSql;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.FreeSql
{
    public interface IServiceKey
    {
        //ILogger Logger { get; }
        IRepositoryUnitOfWork UnitOfWork { get; }
    }
}
