using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using TechLift.FinalProject.Models;

namespace TechLift.FinalProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees_count_group = _context.Employees.GroupBy(emp => emp.Department.DepartmentName).Select(n => new Dtos.User.CustomRecord( n.Key, n.Count())).ToList();

            var sum = 0;
            foreach (var rec in employees_count_group)
            {
                sum += rec.Count;
            }


            ViewBag.res_group_count = employees_count_group;

            ViewBag.total_emp_count = sum;

            return View();
        }
    }
}




//var a = new List<String>(new String[]{ "Ahmed", "Ali", "Hammad", "Umer", "Ahsan", "Ammar", "Fasih", "Ihsan"});

//var b = new List<String>(new String[] { "03316785986", "03329076345", "03329076348", "03329076349", "03329676345", "03329123345", "03329098745", "03329098345" });

//var c = new List<String>(new String[] { "a@a.a", "b@b.b", "c@c.c", "d@d.d", "d@d.d", "e@e.e", "f@f.f", "g@g.g", "h@h.h"});

//var d = new List<String>(new String[] {"a", "b", "c", "d", "e", "f"});

//var departments = _context.Departments.ToList();


//var r = new Random();

//for (int i=0;i<100;++i)
//{
//    var t = new EmployeeViewModel();

//    t.Id = new Guid();
//    t.Name = a[r.Next(a.Count)];
//    t.ContactNumber = b[r.Next(b.Count)];
//    t.Email = c[r.Next(c.Count)];
//    t.Designation = d[r.Next(d.Count)];
//    t.Department = departments[r.Next(departments.Count)];


//    _context.Employees.Add(t);


//}


//_context.SaveChanges();