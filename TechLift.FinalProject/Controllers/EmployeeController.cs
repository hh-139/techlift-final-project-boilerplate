using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using TechLift.FinalProject.Models;

namespace TechLift.FinalProject.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var _employees = _context.Employees.Include(emp => emp.Department).ToList();

            return View(_employees);
        }


        public IActionResult Create()
        {
            var _departments = new SelectList(_context.Departments, "Id", "DepartmentName");

            ViewBag.dept = _departments;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                emp.Id = new Guid();

                var res = await _context.Employees.AddAsync(emp);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Employee");
        }

    }
}
