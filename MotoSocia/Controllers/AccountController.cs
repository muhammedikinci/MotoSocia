using Application;
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
        private ICommander _commander;

        public AccountController(ICommander commander)
        {
            _commander = commander;
        }

        public IActionResult Index()
        {
            _commander.ExecuteWithoutContext<GetCurrentClaims, object>(HttpContext.User.Claims);

            var getCurrentClaims = _commander.GetInstance<GetCurrentClaims>();

            return View(getCurrentClaims.User);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            _commander.ExecuteWithoutContext<GetCurrentClaims, object>(HttpContext.User.Claims);
            _commander.Execute<GetUserData, object>(_commander.GetResult()[0]);

            var getUserData = _commander.GetInstance<GetUserData>();

            return View(getUserData.FullData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateRecaptcha]
        public IActionResult EditProfilePost(UpdateUserModel updateUserModel)
        {
            if (ModelState.IsValid)
                return View("EditProfile");

            _commander.ExecuteWithoutContext<GetCurrentClaims, object>(HttpContext.User.Claims);
            updateUserModel.UserName = _commander.GetInstance<GetCurrentClaims>().User.UserName;
            _commander.Execute<UpdateUser, object>(updateUserModel);

            var updateUser = _commander.GetInstance<UpdateUser>();

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