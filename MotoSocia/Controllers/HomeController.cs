using Microsoft.AspNetCore.Mvc;
using Application;

namespace MotoSocia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
