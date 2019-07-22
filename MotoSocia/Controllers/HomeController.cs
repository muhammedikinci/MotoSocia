using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotoSocia.Controllers
{
    [Authorize]
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
