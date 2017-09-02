using System.Collections.Generic;
using System.Threading.Tasks;
using TakeHome.Core.Entities;


namespace TakeHome.Core.Services
{
    public interface IEmployeeCaseService :IService<EmployeeCase>
    {
        List<EmployeeCase> GetCasesByEmployee(int EmployeeId);
    }
}
