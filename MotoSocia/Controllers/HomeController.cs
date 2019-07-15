using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Commands.User;
using Application.Models;
using System.IO;
using System.Text;

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

        public JsonResult CreateNewUser(User user)
        {
            CreateNewUser CreateNewUserCommand = new CreateNewUser(_context, user);

            Inv = new Invoker(CreateNewUserCommand);
            Inv.Execute();

            return new JsonResult("{\"type\": \"success\"}");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
