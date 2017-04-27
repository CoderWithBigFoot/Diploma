using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareYourself.WebUI.Controllers
{
    public class UserProfileController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        

    }
}