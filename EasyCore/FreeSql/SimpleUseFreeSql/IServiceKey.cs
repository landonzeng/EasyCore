using FreeSql;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCore.FreeSql.SimpleUseFreeSql
{
    public interface IServiceKey
    {
        IRepositoryUnitOfWork UnitOfWork { get; }
    }
}
