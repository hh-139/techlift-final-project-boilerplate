using Microsoft.AspNetCore.Identity;
using TechLift.FinalProject.Dtos.User;
using TechLift.FinalProject.Roles;

namespace TechLift.FinalProject.Acount
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRoleService _roleService;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IRoleService roleService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleService = roleService;
        }
        public async Task<IdentityResult> CreateUserAsync(UserSignUpDto userSignUpDto)
        {
            var user = new IdentityUser
            {
                Email = userSignUpDto.EmailAddress,
                UserName = userSignUpDto.EmailAddress,
            };
            var result = await _userManager.CreateAsync(user, userSignUpDto.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(UserSignInDto userSignInDto)
        {
            return await _signInManager.PasswordSignInAsync(userSignInDto.EmailAddress, userSignInDto.Password, false, true);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}