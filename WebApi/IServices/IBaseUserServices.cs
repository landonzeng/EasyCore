using EasyCore.FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Module;

namespace WebApi.IServices
{
    public interface IBaseUserServices: IServiceKey
    {
        Task<List<LR_Base_User>> GetList();
    }
}
