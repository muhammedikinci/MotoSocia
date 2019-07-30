using Application;
using Application.Models.User;
using Application.Actions.User;
using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Infrastructure.Email;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private ICommander _commander;

        public UserController(Application.ICommander commander)
        {
            _commander = commander;
        }

        [Route("login")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserModel user)
        {
            if (ModelState.IsValid)
            {
                _commander.Execute<LoginAction, LoginUserModel>(user);
                var loginAction = _commander.GetInstance<LoginAction>();

                if (loginAction.LoggedInUserData != null && 
                    !string.IsNullOrEmpty(loginAction.LoggedInUserData.UserName) &&
                    !string.IsNullOrEmpty(loginAction.LoggedInUserData.Email))
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewUser(NewUserModel user)
        {
            if (ModelState.IsValid)
            {
                _commander.Execute<NewUserAction, NewUserModel>(user);
                var newUserAction = _commander.GetInstance<NewUserAction>();
                
                if (newUserAction.Result)
                {
                    SendGrid.Response mailResponse = await EmailService.SendMail<ConfirmMail>(user.Email, user.Name, user.Surname);

                    if (mailResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        TempData["Message"] = "Kaydınız başarıyla oluşturuldu.";
                        TempData["Success"] = true;

                        await SetLoginClaims(user);
                    }
                    else
                    {
                        var body = await mailResponse.Body.ReadAsStringAsync();

                        TempData["Message"] = "Kaydınız başarıyla oluşturuldu. Doğrulama maili gönderme sırasında hata algılandı. \n" + body;
                        TempData["Success"] = false;
                    }
                }
                else
                {
                    TempData["Message"] = "Kayıt sırasında bir hata oluştu!";
                    TempData["Success"] = false;
                }

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