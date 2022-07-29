using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerASPNET.Models
{
    public class ProjectToEmployees
    {
        [Key]
        public int Id { get; set; }
        
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Projects Projects { get; set; }
        public int EmployeesId { get; set; }
        [ForeignKey("EmployeesId")]
        public Employees Employees { get; set; }
    }
}
