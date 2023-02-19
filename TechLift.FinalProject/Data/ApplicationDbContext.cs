using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechLift.FinalProject.Models;

namespace ServiceLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EmployeeViewModel> Employees { get; set; }
        public DbSet<DepartmentViewModel> Departments { get; set; }
    }
}
