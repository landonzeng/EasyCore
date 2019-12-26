using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.FreeSql.UseUnitOfWork;
using Exceptionless;
using WebApi.IRepository;
using WebApi.IServices;
using WebApi.Module;

namespace WebApi.Services
{
    public class DepartmentInfoService : IDepartmentInfoService
    {
        private readonly IDepartmentInfoRepository _departmentInfoRepository;
        private readonly IFreeSqlUnitOfWorkManager _uowManager;
        public DepartmentInfoService(IDepartmentInfoRepository departmentInfoRepository, IFreeSqlUnitOfWorkManager uowManager)
        {
            _departmentInfoRepository = departmentInfoRepository;
            _uowManager = uowManager;
        }

        public async Task<Tbiz_DepartmentInfo> GetAsync(long id)
        {
            var model = await _departmentInfoRepository.Orm.GetRepository<Tbiz_DepartmentInfo>().Select.Where(it => it.Id == id).FirstAsync();
            return model;
        }

        public async Task<List<Tbiz_DepartmentInfo>> FindListAsync()
        {
            return await _departmentInfoRepository.Select.ToListAsync();
        }

        public async Task<int> DeleteAsync(long Id)
        {
            int count = await _departmentInfoRepository.DeleteAsync(x => x.Id == Id);
            await _uowManager.CommitAsync();
            return count;
        }

        public async Task<int> UpdateAsync(Tbiz_DepartmentInfo log)
        {
            int result = 0;

            try
            {
                result = await _departmentInfoRepository.UpdateAsync(log);
                await _uowManager.CommitAsync();
            }
            catch (Exception ex) {
                ex.ToExceptionless().Submit();
            }
            return result;
        }
    }
}
