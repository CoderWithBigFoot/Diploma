using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareYourself.WebUI.Models;
using System.Globalization;

namespace ShareYourself.WebUI.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditUserProfile()
        {
            var editUserProfileModel = new UserProfileEditingViewModel
            {
                Name = "Zheka",
                Surname = "Korsakas",
                Status = "Some status is here",
                IsMale = true,
                BirthDate = DateTime.Now
            };
            //DateTimeFormatInfo info = new DateTimeFormatInfo();

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