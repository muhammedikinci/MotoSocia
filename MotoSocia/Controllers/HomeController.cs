using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Commands.User;
using Application.Models;
using System.IO;
using System.Text;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace MotoSocia.Controllers
{
    public class HomeController : Controller
    {
        private Persistence.MotoDBContext _context;
        private Invoker Inv;

        public HomeController(Persistence.MotoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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

                ViewBag.Result = "Başarılı";
                return View("Index");
            }
            else
            {
                ViewBag.Result = "Başarısız";
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
