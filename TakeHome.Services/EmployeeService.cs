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
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
                
        }
    }
}
