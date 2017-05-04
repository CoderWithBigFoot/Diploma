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
        private IUserImageService _userImageService;
        private string _errorView = "~/Views/Shared/Error.cshtml";

        public UserProfileController(IUserProfileService userProfileService, IUserImageService userImageService)
        {
            _userProfileService = userProfileService;
            _userImageService = userImageService;
        }

        [HttpGet]
        public ActionResult ProfilePage()
        {
            var userProfileInfo = _userProfileService.Get<UserProfileDto>(User.Identity.Name);
            var mappedUserProfile = Mapper.Map<UserProfileHomeViewModel>(userProfileInfo);

            if(mappedUserProfile == null)
            {
                ViewBag.ErrorMessage = "Such profile not found";
                return View(_errorView);                
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
    }
}