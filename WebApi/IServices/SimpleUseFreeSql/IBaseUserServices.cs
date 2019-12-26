using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCore.FreeSql.SimpleUseFreeSql;
using WebApi.Module;

namespace WebApi.IServices.SimpleUseFreeSql
{
    public interface IBaseUserServices : IServiceKey
    {
        Task<List<LR_Base_User>> GetList();
    }
}
