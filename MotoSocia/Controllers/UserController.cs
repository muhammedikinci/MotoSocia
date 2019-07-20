using Application.Command;
using Application.Models.User;
using Application.Actions.User;
using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private Persistence.MotoDBContext _context;

        public UserController(Persistence.MotoDBContext context)
        {
            _context = context;
        }

        [Route("login")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha]
        public async Task<IActionResult> Login(LoginUserModel user)
        {
            if (ModelState.IsValid)
            {
                var loginAction = new LoginAction(_context, user);
                var command = new Invoker<LoginAction>(loginAction);
                command.Invoke();

                if (loginAction.LoggedInUserData != null)
                {
                    await SetLoginClaims(new NewUserModel() { Email = loginAction.LoggedInUserData.Email, UserName = loginAction.LoggedInUserData.UserName });

                    return RedirectToRoute("homepage");
                }
                else
                {
                    ViewBag.Message = "Kimlik doğrulaması başarısız.";
                    ViewBag.Success = false;
                    return View("SignIn");
                }

            }
            else
            {
                ViewBag.Message = "Geçersiz CAPTCHA";
                ViewBag.Success = false;
                return View("SignIn");
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha]
        public async Task<IActionResult> CreateNewUser(NewUserModel user)
        {

            if (ModelState.IsValid)
            {
                var newUserAction = new NewUserAction(_context, user);
                var command = new Invoker<NewUserAction>(newUserAction);
                command.Invoke();

                await SetLoginClaims(user);

                TempData["Message"] = "Kaydınız Başarıyla Yapılmıştır.";
                TempData["Success"] = true;
                return RedirectToRoute("homepage");
            }
            else
            {
                ViewBag.Message = "Geçersiz CAPTCHA";
                ViewBag.Success = false;
                return View("SignUp");
            }
        }

        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return RedirectToRoute("login");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToRoute("homepage");
        }

        public async Task SetLoginClaims (NewUserModel user)
        {
            var claims = new List<Claim>   {
                        new Claim(ClaimTypes.NameIdentifier, user.Email),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
        }
    }
}