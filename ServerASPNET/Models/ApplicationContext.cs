using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ServerASPNET.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Projects> Projects { get; set; }
        public DbSet<CompanyCustomers> CompanyCustomers { get; set; }
        public DbSet<PerformingCompanys> PerformingCompany { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<ProjectToEmployees> ProjectToEmployees { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
