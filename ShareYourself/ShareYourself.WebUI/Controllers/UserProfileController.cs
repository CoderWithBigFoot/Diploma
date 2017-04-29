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
            var editUserProfileModel = new UserProfileEditingViewModel
            {
                Name = "Zheka",
                Surname = "Korsakas",
                Status = "Some status is here",
                IsMale = true
            };
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            //ViewBag.CurrentMonth = info.GetMonthName(DateTime.Now.Month);
            return View("EditUserProfile", editUserProfileModel);
        }

        [HttpPost]
        public ActionResult EditUserProfile(UserProfileEditingViewModel model)
        {
            if(model.IsMale != null)
            {
                if(model.IsMale == true)
                {
                    ViewBag.ResultMessage = "Success";
                    return View();
                }
            }
            ViewBag.ResultMessage = "Model is incorrect";
            return View();
        }


    }
}