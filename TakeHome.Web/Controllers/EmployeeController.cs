using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TakeHome.Core.Entities;
using TakeHome.Core.Services;
using TakeHome.ViewModels;

namespace TakeHome.Web
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployees()
        {
            List<Employee> employees = await _employeeService.GetAllAsync();

            List<EmployeeViewModel> EmployeesList = new List<EmployeeViewModel>();
            foreach (Employee e in employees)
            {
                var employeeViewModel = new EmployeeViewModel();
                employeeViewModel.FirstName = e.FirstName;
                employeeViewModel.LastName = e.LastName;
                employeeViewModel.EmployeeNumber = e.EmployeeNumber;
                employeeViewModel.Id = e.Id;
                EmployeesList.Add(employeeViewModel);
            }
            //TO DO: Check the mappings
            //Mapper.Map(employees, EmployeesList);

            return Ok(EmployeesList);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeViewModel Employee = new EmployeeViewModel();

            //Mapper.Map(employee, Employee);
            Employee.EmployeeNumber = employee.EmployeeNumber;
            Employee.FirstName = employee.FirstName;
            Employee.LastName = employee.LastName;
            return Ok(Employee);
        }

    }
}
