using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api1.Model
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEmployee { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public required string Charge { get; set; }
        [ForeignKey("IDDepartament")]
        public int IDDepartament { get; set; }


    
    }
}
