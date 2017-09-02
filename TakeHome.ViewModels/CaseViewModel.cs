using System;
using TakeHome.Core.Entities;

namespace TakeHome.ViewModels
{
    public class CaseViewModel
    {
        
        public string FirstName { get; set; }

       public string LastName { get; set; }

        public string CaseNumber { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}