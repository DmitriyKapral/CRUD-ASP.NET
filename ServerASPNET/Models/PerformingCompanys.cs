using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerASPNET.Models
{
    public class PerformingCompanys
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
