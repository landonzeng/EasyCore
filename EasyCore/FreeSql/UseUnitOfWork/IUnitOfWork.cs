using System;
using System.Collections.Generic;
using System.Text;
using FreeSql;

namespace EasyCore.FreeSql.UseUnitOfWork
{
    public interface IUnitOfWork<Context> : IUnitOfWork
    {
    }
}
