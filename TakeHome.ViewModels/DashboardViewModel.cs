using System.Collections.Generic;

namespace TakeHome.ViewModels
{
    /// <summary>
    /// Container view model to hold list of cases and employees
    /// </summary>
    public class DashboardViewModel
    {
        /// <summary>
        /// List of cases
        /// </summary>
        public List<CaseViewModel> Cases { get; set; }

        /// <summary>
        /// List of employees
        /// </summary>
        public List<EmployeeViewModel> Employees { get; set; }
    }
}