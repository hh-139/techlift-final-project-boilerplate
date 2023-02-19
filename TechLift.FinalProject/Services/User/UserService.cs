using Microsoft.AspNetCore.Identity;

namespace TechLift.FinalProject.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string GetUserId()
        {
            throw new NotImplementedException();

        }

        public bool ISAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
