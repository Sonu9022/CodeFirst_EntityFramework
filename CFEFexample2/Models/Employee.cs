using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFEFexample2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Column("EmployeeName", TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }
        [Column("EmployeeDesignation", TypeName = "varchar(30)")]
        [Required(ErrorMessage = "Designation is Required")]
        public string Designation { get; set; }
       
       

    }
   
}
