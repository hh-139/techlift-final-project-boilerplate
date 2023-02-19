using Microsoft.AspNetCore.Identity;
using TechLift.FinalProject.Dtos.User;

namespace TechLift.FinalProject.Acount
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(UserSignUpDto userSignUpDto);
        Task<SignInResult> PasswordSignInAsync(UserSignInDto userSignInDto);
        Task SignOutAsync();
    }
}
