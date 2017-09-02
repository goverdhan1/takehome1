using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHome.ViewModels
{
    public class InsertCaseViewModel
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CaseNumber { get; set; }
        public bool Approved { get; set; }
        public bool Denied { get; set; }
    }
}
