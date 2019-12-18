using EasyCore.FreeSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IRepository;
using WebApi.Module;

namespace WebApi.Repository
{
    public class BaseUserRepository : BaseRepository<LR_Base_User, int>, IBaseUserRepository
    {
        public BaseUserRepository(IServiceProvider service) : base(service)
        {
        }
    }
}
