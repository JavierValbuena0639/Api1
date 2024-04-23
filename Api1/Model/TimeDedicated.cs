using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api1.Model
{
    public class TimeDedicated
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeDedicatedId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int IDProyect { get; set; }
        public int WorkedHours { get; set; }


        [ForeignKey("EmployeeId")]
        public virtual Employees IDEmployee { get; set; }
        [ForeignKey("IDProyect")]
        public virtual Projects ProjectId { get; set; }
    }
}
