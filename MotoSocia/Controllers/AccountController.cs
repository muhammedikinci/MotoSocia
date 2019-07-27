using Application.Command;
using Microsoft.AspNetCore.Mvc;
using Application.Actions.Account;
using Microsoft.AspNetCore.Authorization;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Application.Models.User;
using Application.Models.Account;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private Persistence.MotoDBContext _context;

        public AccountController(Persistence.MotoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var getCurrentClaims = new GetCurrentClaims(HttpContext.User.Claims);
            var command = new Invoker<GetCurrentClaims>(getCurrentClaims);

            command.Invoke();

            return View(getCurrentClaims.User);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var getCurrentClaims = new GetCurrentClaims(HttpContext.User.Claims);
            var getCurrentClaimsInvoker = new Invoker<GetCurrentClaims>(getCurrentClaims);

            getCurrentClaimsInvoker.Invoke();

            var getUserData = new GetUserData(_context, getCurrentClaims.User);
            var getUserDataInvoker = new Invoker<GetUserData>(getUserData);

            getUserDataInvoker.Invoke();

            return View(getUserData.FullData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateRecaptcha]
        public IActionResult EditProfilePost(UpdateUserModel updateUserModel)
        {
            if (ModelState.IsValid)
                return View("EditProfile");

            var getCurrentClaims = new GetCurrentClaims(HttpContext.User.Claims);
            var getCurrentClaimsInvoker = new Invoker<GetCurrentClaims>(getCurrentClaims);

            getCurrentClaimsInvoker.Invoke();

            updateUserModel.UserName = getCurrentClaims.User.UserName;

            var updateUser = new UpdateUser(_context, updateUserModel);
            var updateUserInvoker = new Invoker<UpdateUser>(updateUser);

            updateUserInvoker.Invoke();

            if (!updateUser.Status)
            {
                ViewBag.Message = updateUser.ProcessMessage;
                ViewBag.Success = updateUser.Status;

                return View("EditProfile", new NewUserModel() {
                    Email = updateUserModel.Email,
                    Name = updateUserModel.Name,
                    Surname = updateUserModel.Surname
                });
            }
            else
            {
                ViewBag.Message = "Güncelleme başarılı!";
                ViewBag.Success = true;
            }

            return View("Index", new NewUserModel()
            {
                Email = updateUserModel.Email,
                Name = updateUserModel.Name,
                Surname = updateUserModel.Surname
            });
        }
    }
}