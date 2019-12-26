using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.FreeSql.UseUnitOfWork.Repository;
using WebApi.DbContext;
using WebApi.IRepository;
using WebApi.Module;

namespace WebApi.Repository
{
    public class DepartmentInfoRepository : RepositoryBase<Tbiz_DepartmentInfo, IPMWebApi>, IDepartmentInfoRepository
    {
        public DepartmentInfoRepository(IServiceProvider service) : base(service)
        {
        }
    }
}
