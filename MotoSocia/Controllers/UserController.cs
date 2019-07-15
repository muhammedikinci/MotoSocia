using Application;
using Application.Commands.User;
using Application.Models;
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

        [HttpPost]
        [ValidateRecaptcha]
        public IActionResult CreateNewUser(User user)
        {

            if (ModelState.IsValid)
            {
                CreateNewUser CreateNewUserCommand = new CreateNewUser(_context, user);

                Inv = new Invoker(CreateNewUserCommand);
                Inv.Execute();

                ViewBag.Result = "Kaydınız Başarıyla Yapılmıştır.";
                return View("SignUp");
            }
            else
            {
                ViewBag.Result = "Geçersiz CAPTCHA";
                return View("SignUp");
            }
        }
    }
}