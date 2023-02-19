using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechLift.FinalProject.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Employee Name")]
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^((\\+92)?(0092)?(92)?(0)?)(3)([0-9]{9})$/gm", ErrorMessage = "Invalid Mobile Number.")]
        public String? ContactNumber { get; set; }

        [Display(Name = "User Email:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Designation")]
        [MaxLength(50)]
        [Required]
        public String? Designation { get; set; }

        [Required]
        public DepartmentViewModel? Department { get; set; }
    }
}
