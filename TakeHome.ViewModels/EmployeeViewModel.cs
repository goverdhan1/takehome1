using System.Collections.Generic;
using TakeHome.Core.Entities;

namespace TakeHome.ViewModels
{
    public class EmployeeViewModel
    {
        //public EmployeeViewModel()
        //{

        //}

        //public EmployeeViewModel(Employee emp)
        //    :this()
        //{
        //    if (emp == null)
        //        return;

        //    Id = emp.Id;
        //    FirstName = emp.FirstName;
        //    LastName = emp.LastName;
        //    EmployeeNumber = emp.EmployeeNumber;
        //}

        /// <summary>
        /// Unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Employee Number
        /// </summary>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// The Employee's Cases
        /// </summary>
        public List<CaseViewModel> Cases { get; set; }
    }
}