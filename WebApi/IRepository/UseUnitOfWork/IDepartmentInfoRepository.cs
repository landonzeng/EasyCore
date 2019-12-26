using EasyCore.FreeSql.UseUnitOfWork.IRepository;
using WebApi.DbContext;
using WebApi.Module;

namespace WebApi.IRepository
{
    public interface IDepartmentInfoRepository : IRepositoryBase<Tbiz_DepartmentInfo, IPMWebApi>
    {
    }
}
