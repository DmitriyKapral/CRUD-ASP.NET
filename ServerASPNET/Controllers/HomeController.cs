using Microsoft.AspNetCore.Mvc;
using ServerASPNET.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ServerASPNET.ViewModels;

namespace ServerASPNET.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("hello")]
        public IActionResult GetName(string name)
        {
            Testing test = new Testing();
            test.name = "hello";
            test.age = 12;

            List<Testing> tests = new List<Testing>();

            tests.Add(new Testing()
            {
                name = "hello",
                age = 12,
            });

            return Ok(tests);
            
        }
        [HttpGet("Employee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employees employee = db.Employees.SingleOrDefault(x => x.Id == id);
            return Ok(employee);
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employees employees)
        {
            db.Employees.Add(employees);
            db.SaveChanges();
            return Ok(200);
        }
        [HttpPost("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee([FromBody] Employees employees, int id)
        {
            Employees employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                employee.Name = employees.Name;
                employee.Surname = employees.Surname;
                employee.Patronymic = employees.Patronymic;
                employee.Email = employees.Email;
                db.SaveChanges();
                return Ok(200);
            }
            else
                return BadRequest();
        }
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employees employee = db.Employees.FirstOrDefault(x => x.Id==id);
            if (employee != null)
            {
                db.Remove(employee);
                db.SaveChanges();
                return Ok(200);
            }
            else
                return BadRequest();
        }

        [HttpDelete("DeleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            Projects project = db.Projects.FirstOrDefault(x => x.Id == id);
            if (project != null)
            {
                db.Remove(project);
                db.SaveChanges();
                return Ok(200);
            }
            else
                return BadRequest();
        }

        [HttpGet("Project/{id}")]
        public IActionResult GetProject(int id)
        {
            ProjectsView projectsView = new ProjectsView();
            Projects projects = db.Projects.FirstOrDefault(x => x.Id == id);
            projectsView.Id = id;
            projectsView.Name = projects.Name;
            projectsView.Start = projects.Start;
            projectsView.End = projects.End;
            projectsView.Priority = projects.Priority;
            projectsView.CustomerName = db.CompanyCustomers.FirstOrDefault(x => x.Id == projects.CompanyCustomersId).Name;
            projectsView.PerformingName = db.PerformingCompany.FirstOrDefault(x => x.Id == projects.PerformingCompanyId).Name;
            projectsView.ProjectManager = db.Employees.FirstOrDefault(x => x.Id == projects.ProjectManagersId);
            return Ok(projectsView);
        }
        [HttpPost("AddProject")]
        public IActionResult AddProject([FromBody] Projects projects)
        {
           
            db.Projects.Add(projects);
            db.SaveChanges();
            return Ok(200);
        }






    }
}