using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.FreeSql;
using Util.Dependency;
using WebApi.Module;

namespace WebApi.IServices
{
    public interface IDepartmentInfoService: IScopeDependency
    {
        public Task<Tbiz_DepartmentInfo> GetAsync(long id);
        public Task<List<Tbiz_DepartmentInfo>> FindListAsync();

        public Task<int> DeleteAsync(long Id);

        public Task<int> UpdateAsync(Tbiz_DepartmentInfo log);
    }
}
