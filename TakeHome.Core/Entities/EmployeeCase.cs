namespace TakeHome.Core.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmployeeCase")]
    public partial class EmployeeCase :BaseEntity
    {

        public int EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(10)]
        public string CaseNumber { get; set; }

        public bool Approved { get; set; }

        public bool Denied { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
