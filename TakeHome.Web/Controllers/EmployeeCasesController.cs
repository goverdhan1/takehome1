using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TakeHome.Core.Entities;
using TakeHome.Core.Services;
using TakeHome.ViewModels;

namespace TakeHome.Web
{
    [RoutePrefix("api/EmployeeCases")]
    public class EmployeeCasesController : ApiController
    {
        private readonly IEmployeeCaseService _employeeCaseService;
        private readonly IEmployeeService _employeeService;
        public EmployeeCasesController(IEmployeeCaseService employeeCaseService, IEmployeeService employeeService)
        {
            _employeeCaseService = employeeCaseService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllCases()
        {

            List<CaseViewModel> caseList = new List<CaseViewModel>();

            List<EmployeeCase> employeeCases = await _employeeCaseService.GetAllAsync();

            foreach (EmployeeCase c in employeeCases)
            {
                var cViewModel = new CaseViewModel();
                cViewModel.FirstName = c.Employee.FirstName;
                cViewModel.LastName = c.Employee.LastName;
                cViewModel.CaseNumber = c.CaseNumber;
                cViewModel.Status = GetStatus(c.Approved,c.Denied);
                caseList.Add(cViewModel);
            }

            return Ok(caseList);
        }

        private string GetStatus(bool isApproved, bool isRejected)
        {
            string Status = string.Empty;
            if (isApproved)
                Status = "Approved";
            else if (isRejected)
                Status =  "Denied";
            return Status;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCaseByEmployee(int id)
        {

            CaseListByEmployeeViewModel caseList = new CaseListByEmployeeViewModel();

            List<EmployeeCase> employeeCases = _employeeCaseService.GetCasesByEmployee(id);
            //Mapper.Map(employeeCases, caseList.caseList);
            List<CaseViewModel> cases = new List<CaseViewModel>();
            foreach (EmployeeCase ec in employeeCases)
            {
                var singleCase = new CaseViewModel();
                singleCase.CaseNumber = ec.CaseNumber;
                singleCase.Status = GetStatus(ec.Approved, ec.Denied);
                singleCase.StartDate = ec.StartDate;
                singleCase.EndDate = ec.EndDate;
                cases.Add(singleCase);
            }
            caseList.caseList = cases;

            Employee employee = await _employeeService.GetByIdAsync(id);
            //Mapper.Map(employee, caseList.Employee);
            EmployeeViewModel eViewModel = new EmployeeViewModel();

            eViewModel.FirstName = employee.FirstName;
            eViewModel.LastName = employee.LastName;
            eViewModel.EmployeeNumber = employee.EmployeeNumber;

            caseList.Employee = eViewModel;

            return Ok(caseList);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeViewModel Employee = new EmployeeViewModel();

            Mapper.Map(employee, Employee);

            return Ok(Employee);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostCase(CaseViewModel caseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeCase employeeCase = new EmployeeCase();
            //Mapper.Map(caseViewModel, employeeCase);
            _employeeCaseService.AddAsync(employeeCase);
            return CreatedAtRoute("ApiRoute", new { id = employeeCase.Id }, caseViewModel);
        }
    }
}
