using System.Collections.Generic;
using TakeHome.Core.Entities;

namespace TakeHome.Core.Data.Repositories
{
    public interface IEmployeeCaseRepository: IRepository<EmployeeCase>
    {
        List<EmployeeCase> GetCasesByEmployee(int id);
    }
}
