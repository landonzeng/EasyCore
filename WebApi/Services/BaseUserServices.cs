using EasyCore.FreeSql;
using FreeSql;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IRepository;
using WebApi.IServices;
using WebApi.Module;

namespace WebApi.Services
{
    public class BaseUserServices : BaseService, IBaseUserServices
    {
        private readonly BaseRepository<LR_Base_User> _iBaseUserRepository;

        public BaseUserServices(IServiceProvider service) : base(service)
        {
            _iBaseUserRepository = UnitOfWork.GetRepository<LR_Base_User>();
        }

        //private readonly ILogger _logger;
        //public BaseUserServices(IServiceProvider service, ILogger logger) : base(service, logger)
        //{
        //    _iBaseUserRepository = UnitOfWork.GetRepository<LR_Base_User>();
        //    _logger = logger;
        //}

        public async Task<List<LR_Base_User>> GetList()
        {
            return await _iBaseUserRepository.Select.ToListAsync();
        }
    }
}
