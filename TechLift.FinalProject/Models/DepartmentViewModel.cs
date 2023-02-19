using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLift.FinalProject.Models
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }

        [Column("dept_name")]
        [MaxLength(10)]
        [Required]
        public String DepartmentName { get; set; } = String.Empty;
    }
}
