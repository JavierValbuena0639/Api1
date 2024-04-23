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

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        [ForeignKey("IDProject")]
        public int IDProject { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime AssignmentDate { get; set; }

        [Required]
        public string AssignmentHours { get; set; }
    }
}
