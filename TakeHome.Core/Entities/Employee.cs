namespace TakeHome.Core.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee :BaseEntity
    {
        public Employee()
        {
            EmployeeCases = new HashSet<EmployeeCase>();
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeNumber { get; set; }

        public virtual ICollection<EmployeeCase> EmployeeCases { get; set; }
    }
}
