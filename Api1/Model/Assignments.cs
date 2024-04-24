using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api1.Model
{
    public class Assignments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }
        public int EmployeeID { get; set; }
        public int IDProject { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employees IDEmployee { get; set; }

        [ForeignKey("IDProject")]
        public virtual Projects ProjectId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime AssignmentDate { get; set; }

        [Required]
        public string AssignmentHours { get; set; }
    }
}
