using System.Web.Mvc;
using ShareYourself.WebUI.Models;
using System.Globalization;
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
            string email = HttpContext.User.Identity.Name;
            var userProfileInfo = _userProfileService.Get<UserProfileDto>(email);
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
            string email = HttpContext.User.Identity.Name;
            var editingUserProfileModel = _userProfileService.Get<UserProfileEditingDto>(email);
            var mappedEditingUserProfileModel = Mapper.Map<UserProfileEditingViewModel>(editingUserProfileModel);

            if(mappedEditingUserProfileModel == null)
            {
                ViewBag.ErrorMessage = "Such profile not found";
                return Redirect(_errorView);
            }

            return View("EditUserProfile", mappedEditingUserProfileModel);
        }

        [HttpPost]
        public ActionResult EditUserProfile([Bind(Exclude = "Id")] UserProfileEditingViewModel model)
        {
            
        }


    }
}