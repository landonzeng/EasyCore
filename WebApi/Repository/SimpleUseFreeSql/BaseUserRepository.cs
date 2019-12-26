using System;
using EasyCore.FreeSql.SimpleUseFreeSql;
using WebApi.IRepository.SimpleUseFreeSql;
using WebApi.Module;

namespace WebApi.Repository.SimpleUseFreeSql
{
    public class BaseUserRepository : BaseRepository<LR_Base_User, int>, IBaseUserRepository
    {
        public BaseUserRepository(IServiceProvider service) : base(service)
        {
        }
    }
}
