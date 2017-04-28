using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareYourself.WebUI.Models;

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
            var editUserProfileModel = new EditUserProfileViewModel
            {
                Name = "Zheka",
                Surname = "Korsakas",
                Status = "Some status is here"
            };
            return View("EditUserProfile", editUserProfileModel);
        }
    }
}