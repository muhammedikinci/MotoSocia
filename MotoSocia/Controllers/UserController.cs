using Application.CommandPattern;
using Application.Commands.User;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private Persistence.MotoDBContext _context;
        private Invoker Inv;

        public UserController(Persistence.MotoDBContext context)
        {
            _context = context;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha]
        public IActionResult Login(LoginUserModel user)
        {
            if (ModelState.IsValid)
            {
                LoginCommand login = new LoginCommand(_context, user);
                login.Execute();

                if (login.IsLoggedIn)
                {
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

        [HttpPost]
        [ValidateRecaptcha]
        public IActionResult CreateNewUser(NewUserModel user)
        {

            if (ModelState.IsValid)
            {
                NewUserCommand CreateNewUserCommand = new NewUserCommand(_context, user);

                Inv = new Invoker(CreateNewUserCommand);
                Inv.Execute();

                ViewBag.Message = "Kaydınız Başarıyla Yapılmıştır.";
                ViewBag.Success = true;
                return View("SignUp");
            }
            else
            {
                ViewBag.Message = "Geçersiz CAPTCHA";
                ViewBag.Success = false;
                return View("SignUp");
            }
        }
    }
}