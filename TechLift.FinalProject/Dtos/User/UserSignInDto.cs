using System.ComponentModel.DataAnnotations;

namespace TechLift.FinalProject.Dtos.User
{
    public class UserSignInDto
    {
        [Required(ErrorMessage = "Please enter the email address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

    }
}