using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.Actions.Account;
using Application.Actions.Group;
using Application.Models.Group;
using Application.Models.User;
using Application.Models.Values;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace WebUI.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private ICommander _commander;

        public GroupController(ICommander commander)
        {
            _commander = commander;
        }

        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGroupPost(CreateGroupModel createGroupModel, string mediaLink1Title, string mediaLink1, string mediaLink2Title, string mediaLink2, string mediaLink3Title, string mediaLink3)
        {
            if (ModelState.IsValid)
            {
                _commander.Execute<GetCurrentClaims, IEnumerable<Claim>>(HttpContext.User.Claims);
                _commander.Execute<GetUserData, NewUserModel>((NewUserModel)_commander.GetResult()[0]);

                var getUserData = _commander.GetInstance<GetUserData>();

                var MediaLinks = new List<MediaLink>();

                if (!string.IsNullOrEmpty(mediaLink1) && !string.IsNullOrEmpty(mediaLink1Title))
                {
                    MediaLinks.Add(new MediaLink() { Link = mediaLink1, LinkTitle = mediaLink1Title });
                    
                }

                if (!string.IsNullOrEmpty(mediaLink2) && !string.IsNullOrEmpty(mediaLink2Title))
                {
                    MediaLinks.Add(new MediaLink() { Link = mediaLink2, LinkTitle = mediaLink2Title });

                }

                if (!string.IsNullOrEmpty(mediaLink3) && !string.IsNullOrEmpty(mediaLink3Title))
                {
                    MediaLinks.Add(new MediaLink() { Link = mediaLink3, LinkTitle = mediaLink3Title });

                }

                _commander.Execute<CreateGroupAction, object[]>(new object[] {
                    getUserData.FullData,
                    createGroupModel,
                    MediaLinks
                });

                var result = (bool)_commander.GetResult()[0];

                if (result)
                {
                    ViewBag.Message = "Grup başarıyla oluşturuldu.";
                    ViewBag.Success = true;

                    return View("CreateGroup");
                }
                else
                {
                    ViewBag.Message = "Form alanlarını doğru doldurduğunuzdan emin olun!";
                    ViewBag.Success = false;

                    return View("CreateGroup");
                }
            }
            else
            {
                ViewBag.Message = "Form alanlarını doğru doldurduğunuzdan emin olun!";
                ViewBag.Success = false;

                return View("CreateGroup");
            }
        }
    }
}