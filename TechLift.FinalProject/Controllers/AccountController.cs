using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechLift.FinalProject.Acount;
using TechLift.FinalProject.Dtos.User;
using TechLift.FinalProject.Roles;

namespace WebIdentityDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
        }

        [Route(nameof(SignUp))]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(SignUp))]
        public async Task<IActionResult> SignUp(UserSignUpDto request)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountService.CreateUserAsync(request);
                if (!res.Succeeded)
                {
                    foreach (var itemError in res.Errors)
                    {
                        ModelState.AddModelError("", itemError.Description);
                        return View(request);
                    }
                }
                ModelState.Clear();
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("SignUp", "Account");
        }

        [Route(nameof(Login))]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(UserSignInDto request)
        {

            if (ModelState.IsValid)
            {
                var res = await _accountService.PasswordSignInAsync(request);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (res.IsNotAllowed)
                    ModelState.AddModelError("", "Not Allowed to login");
                else if (res.IsLockedOut)
                {
                    ModelState.AddModelError("", "Account is blocked try after Sometime");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                }
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return View("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
