using System;
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
        private string _errorView = "~/Views/Shared/Error.cshtml";

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public ActionResult Home()
        {
            var userProfileInfo = _userProfileService.Get<UserProfileDto>(User.Identity.Name);
            var mappedUserProfile = Mapper.Map<UserProfileHomeViewModel>(userProfileInfo);

            if(mappedUserProfile == null)
            {
                ViewBag.ErrorMessage = "Such profile not found";
                return View(_errorView);                
            }
           
            return View("Home", mappedUserProfile);
        }

        [HttpGet]
        public ActionResult EditUserProfile()
        {
            var editingUserProfileModel = _userProfileService.Get<UserProfileEditingDto>(User.Identity.Name);
            var mappedEditingUserProfileModel = Mapper.Map<UserProfileEditingViewModel>(editingUserProfileModel);

            if(mappedEditingUserProfileModel == null)
            {
                ViewBag.ErrorMessage = "Such profile not found";
                return Redirect(_errorView);
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

                    ViewBag.ResultMessage = "Your profile successfully updated.";
                }
                catch(Exception)
                {
                    ViewBag.ResultMessage = "Unknown server error.";
                }
            }
            return View("EditUserProfile", model);
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image)
        {
            if (image == null)
            {
                ModelState.AddModelError("", "Incorrect image");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UserProfileAvatarDto item = new UserProfileAvatarDto();
                    item.MimeType = image.ContentType;
                    item.Content = new byte[image.ContentLength];
                    image.InputStream.Read(item.Content, 0, image.ContentLength);

                    _userProfileService.Update(item);
                }
                catch (Exception ex)
                {
                    ViewBag.ResulMessage = ex.Message;
                }
            }

            return View("Index");
        }
    }
}