using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerASPNET.Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Priority { get; set; }
        public int CompanyCustomersId { get; set; }
        [ForeignKey("CompanyCustomersId")]
        public CompanyCustomers CompanyCustomers { get; set; }
        public int PerformingCompanyId { get; set; }
        [ForeignKey("PerformingCompanyId")]
        public PerformingCompanys PerformingCompanys { get; set; }
        public int ProjectManagersId  { get; set; }
        [ForeignKey("ProjectManagersId")]
        public Employees Employees { get; set; }

    }
}
