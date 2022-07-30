using Microsoft.AspNetCore.Mvc;
using ServerASPNET.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ServerASPNET.ViewModels;
using System.Linq;

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
            Employees employee = db.Employees.Single(x => x.Id == id);
            return Ok(employee);
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employees employees)
        {
            db.Employees.Add(employees);
            db.SaveChanges();
            return Ok(200);
        }
        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employees employees)
        {
            Employees employee = db.Employees.First(x => x.Id == employees.Id);
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
            Employees employee = db.Employees.First(x => x.Id==id);
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
            Projects project = db.Projects.First(x => x.Id == id);
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
            Projects projects = db.Projects.First(x => x.Id == id);
            projectsView.Id = id;
            projectsView.Name = projects.Name;
            projectsView.Start = projects.Start;
            projectsView.End = projects.End;
            projectsView.Priority = projects.Priority;
            projectsView.CustomerName = db.CompanyCustomers.First(x => x.Id == projects.CompanyCustomersId).Name;
            projectsView.PerformingName = db.PerformingCompany.First(x => x.Id == projects.PerformingCompanyId).Name;
            projectsView.ProjectManager = db.Employees.First(x => x.Id == projects.ProjectManagersId);
            return Ok(projectsView);
        }
        [HttpPost("AddProject")]
        public IActionResult AddProject([FromBody] ProjectsView projectsView)
        {
            Projects projects = new Projects();
            projects.Id = db.Projects.ToList().Last().Id + 1;
            projects.Name = projectsView.Name;
            projects.Start = projectsView.Start;
            projects.End = projectsView.End;
            projects.Priority = projectsView.Priority;
            projects.CompanyCustomersId = db.CompanyCustomers.First(x => x.Name == projectsView.CustomerName).Id;
            projects.PerformingCompanyId = db.PerformingCompany.First(x => x.Name == projectsView.PerformingName).Id;
            projects.ProjectManagersId = db.Employees.First(x => x.Id == projectsView.ProjectManager.Id).Id;
            db.Projects.Add(projects);
            db.SaveChanges();
            return Ok(200);
        }
        [HttpGet("Projects")]
        public IActionResult GetProjects()
        {
            List<ProjectWithEmployeesView> projectWithEmployeesViews = new List<ProjectWithEmployeesView>();
            List<Projects> projects = db.Projects.ToList();
            foreach (var project in projects)
            {
                List<int> employeesId = db.ProjectToEmployees.Where(x => x.ProjectId == project.Id).Select(x=>x.EmployeesId).ToList();
                List<Employees> employees = db.Employees.Where(x => employeesId.Contains(x.Id)).ToList();
                projectWithEmployeesViews.Add(new ProjectWithEmployeesView()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Start = project.Start,
                    End = project.End,
                    Priority = project.Priority,
                    CustomerName = db.CompanyCustomers.First(x => x.Id == project.CompanyCustomersId).Name,
                    PerformingName = db.PerformingCompany.First(x => x.Id == project.PerformingCompanyId).Name,
                    ProjectManager = db.Employees.First(x => x.Id == project.ProjectManagersId),
                    Employees = employees,
                });
                    
            }
            
            return Ok(projectWithEmployeesViews ?? new List<ProjectWithEmployeesView>());
        }
        [HttpPost("UpdateProject")]
        public IActionResult UpdateProject([FromBody] ProjectsView projectsView)
        {
            Projects projects = db.Projects.First(x => x.Id == projectsView.Id);
            if (projects != null)
            {
                projects.Name = projectsView.Name;
                projects.Start = projectsView.Start;
                projects.End = projectsView.End;
                projects.Priority = projectsView.Priority;
                projects.CompanyCustomersId = db.CompanyCustomers.First(x => x.Name == projectsView.CustomerName).Id;
                projects.PerformingCompanyId = db.PerformingCompany.First(x => x.Name == projectsView.PerformingName).Id;
                projects.ProjectManagersId = db.Employees.First(x => x.Id == projectsView.ProjectManager.Id).Id;
                db.SaveChanges();
                return Ok(200);
            }
            else
                return BadRequest();
        }
        [HttpPost("AddProjectWorker/{idProject}")]
        public IActionResult AddProjectWorker(int idProject, [FromBody] int[] idsEmployeers)
        {
            for(int i = 0; i < idsEmployeers.Length; i++)
            {
                ProjectToEmployees projectToEmployees = new ProjectToEmployees();
                projectToEmployees.Id = db.ProjectToEmployees.ToList().Last().Id + 1;
                projectToEmployees.ProjectId = idProject;
                projectToEmployees.EmployeesId = idsEmployeers[i];
                db.ProjectToEmployees.Add(projectToEmployees);
                db.SaveChanges();
            }
            return Ok(200);
        }
        [HttpDelete("DeleteProjectWorker/{idProject}")]
        public IActionResult DeleteProjectWorker(int idProject, [FromBody] int[] idsEmployeers)
        {
            for (int i = 0; i < idsEmployeers.Length; i++)
            {
                ProjectToEmployees projectToEmployees = db.ProjectToEmployees.Where(x => x.ProjectId == idProject).First(x => x.EmployeesId == idsEmployeers[i]);
                db.ProjectToEmployees.Remove(projectToEmployees);
                db.SaveChanges();
            }
            return Ok(200);
        }




    }
}