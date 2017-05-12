using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ShareYourself.WebUI.Models;
using ShareYourself.Business;
using ShareYourself.Business.Dto;
using AutoMapper;

namespace ShareYourself.WebUI.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private IUserProfileService _userProfileService;
        private IUserImageService _userImageService;

        public UserProfileController(IUserProfileService userProfileService, IUserImageService userImageService)
        {
            _userProfileService = userProfileService;
            _userImageService = userImageService;
        }

        [HttpGet]
        [ActionName("MyProfile")]
        public ActionResult ProfilePage()
        {
            var currentUserId = _userProfileService.Get<UserProfileIdDto>(HttpContext.User.Identity.Name).Id;
            return ProfilePage(currentUserId);
        }

        [HttpGet]
        public ActionResult ProfilePage(int id)
        {
            var currentUserId = _userProfileService.Get<UserProfileIdDto>(HttpContext.User.Identity.Name).Id;
            if (id != currentUserId)
            {
                bool isSubscription = _userProfileService.IsSubscribedOn(currentUserId, id);
                ViewData["IsItSubscribtion"] = isSubscription;
            }
            
            var userProfileInfo = _userProfileService.Get<UserProfileDto>((int)id);
            var mappedUserProfile = Mapper.Map<UserProfileHomeViewModel>(userProfileInfo);

            if (mappedUserProfile == null)
            {
                return RedirectToRoute("ErrorRoute", new { message = "Such profile doesn't exist." });
            }

            return View("ProfilePage", mappedUserProfile);   
        }

        [HttpGet]
        public ActionResult EditUserProfile()
        {
            var editingUserProfileModel = _userProfileService.Get<UserProfileEditingDto>(User.Identity.Name);
            var mappedEditingUserProfileModel = Mapper.Map<UserProfileEditingViewModel>(editingUserProfileModel);

            if(mappedEditingUserProfileModel == null)
            {
                ViewBag.ErrorMessage = "Such profile not found";
                return RedirectToRoute("ErrorRoute", new { message = "Some server error."});
            }

            return View("EditUserProfile", mappedEditingUserProfileModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserProfile([Bind(Exclude = "Id")] UserProfileEditingViewModel model)
        {
            if (ModelState.IsValid) // In the view need to check the validation fields (larger size is now)
            {
                try
                {
                    model.Id = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id;
                    var userProfileEditingDto = Mapper.Map<UserProfileEditingDto>(model);
                    _userProfileService.Update(userProfileEditingDto);

                    return RedirectToRoute("MyProfileRoute");
                }
                catch(Exception)
                {
                    ViewBag.ResultMessage = "Unknown server error.";
                }
            }
            return View("EditUserProfile", model);
        }

        [HttpPost]
        public ActionResult EditUserAvatar(HttpPostedFileBase image)
        {
            UserProfileAvatarEditingDto item = new UserProfileAvatarEditingDto();
            item.UserProfileId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id;

            if (image == null)
            {
                item.MimeType = null;
                item.Content = null;
                _userProfileService.Update(item);
            }
                try
                {
                    item.MimeType = image.ContentType;
                    item.Content = new byte[image.ContentLength]; // Here is ebany error suka
                    image.InputStream.Read(item.Content, 0, image.ContentLength);

                     int a = 1;
                    _userProfileService.Update(item);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            return RedirectToAction("ProfilePage");
        }

        [HttpGet]
        public FileResult GetAvatar(int id) // Need to fix the Avatar rotation 
        {
            var avatarId = _userProfileService.Get<UserProfileAvatarIdDto>(id);
            
            if(avatarId.AvatarId == null)
            {
                var path = "~/Content/default-user.jpg";
                return File(path, "image/jpeg");
            }
            else
            {
                var userImageDto = _userImageService.Get<UserImageDto>((int)avatarId.AvatarId);
                return File(userImageDto.Content, userImageDto.MimeType);
            }
        
           // return File(userImageDto.Content, userImageDto.MimeType);// (userImageDto.Content, userImageDto.MimeType);
        }

        [HttpPost]
        public object Subscribe(int toId)
        {
            var userId = _userProfileService.Get<UserProfileEditingDto>(User.Identity.Name).Id;
            _userProfileService.Subscribe(userId, toId);

            return Json(new
            {
                isItSubscription = _userProfileService.IsSubscribedOn(userId, toId),
                toId = toId
            });
        }

        [HttpGet]
        public ActionResult Subscriptions()
        {
            return View();
        }

        [HttpGet]
        [ActionName("GetSubscriptions")]
        public ActionResult Subscriptions(int skip = 0, int count = 4)
        {
            var userId = _userProfileService.Get<UserProfileEditingDto>(User.Identity.Name).Id;
            var subscriptions = _userProfileService.GetSubscriptions(userId, skip, count);
            var result = Mapper.Map<IEnumerable<SubscriptionInfoViewModel>>(subscriptions);

            return PartialView("~/Views/UserProfile/SubscriptionsPartial.cshtml", result);
        }
    }
}