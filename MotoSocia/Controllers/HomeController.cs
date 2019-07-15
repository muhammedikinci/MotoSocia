using Microsoft.AspNetCore.Mvc;

namespace MotoSocia.Controllers
{
    public class HomeController : Controller
    {
        [Route("/", Name = "homepage")]
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Success = TempData["Success"];

            return View();
        }
    }
}
