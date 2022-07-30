using ServerASPNET.Models;

namespace ServerASPNET.ViewModels
{
    public class ProjectWithEmployeesView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Priority { get; set; }
        public string CustomerName { get; set; }
        public string PerformingName { get; set; }
        public Employees ProjectManager { get; set; }
        public List<Employees> Employees { get; set; }
    }
}
