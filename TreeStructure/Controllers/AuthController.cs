using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TreeStructure.ViewModels;

namespace TreeStructure.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var loginStatus = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            if(loginStatus.Succeeded)
            {
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                ViewBag.Message = "Podano nieprawidłowe dane. Spróbuj ponownie!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}