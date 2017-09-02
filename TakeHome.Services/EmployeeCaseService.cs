using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHome.Core.Data.Repositories;
using TakeHome.Core.Entities;
using TakeHome.Core.Services;
using TakeHome.Data;

namespace TakeHome.Services
{
    public class EmployeeCaseService : BaseService<EmployeeCase>, IEmployeeCaseService
    {
        private readonly IEmployeeCaseRepository _repository;
        public EmployeeCaseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public EmployeeCaseService(IUnitOfWork unitOfWork, IEmployeeCaseRepository repository) : base(unitOfWork)
        {
            _repository = repository;
        }
        public List<EmployeeCase> GetCasesByEmployee(int EmployeeId)
        {
            return _repository.GetCasesByEmployee(EmployeeId);
        }
    }
}
