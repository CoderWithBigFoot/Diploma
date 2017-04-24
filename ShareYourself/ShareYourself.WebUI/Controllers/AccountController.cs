using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ShareYourself.WebUI.Models;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using ShareYourself.WebUI.Identity.Models;
using ShareYourself.Business;
using AutoMapper;
using ShareYourself.Business.Dto;
using System;

namespace ShareYourself.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserProfileService _userProfileService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? (_userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>());
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserProfileService service)
        {
            _userProfileService = service;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            switch (result)
            {
                case SignInStatus.Success: return RedirectToRoute(new { }); // here is login page
                case SignInStatus.Failure:
                default: ModelState.AddModelError("", "Invalid login or password");
                    return View(model);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    try
                    {
                        var userDto = Mapper.Map<UserProfileDto>(model);
                        _userProfileService.Create(userDto);
                    }
                    catch(Exception)
                    {
                        ModelState.AddModelError("", "Sorry, service cannot create a new profile");
                        return View(model);
                    }
                    await SignInManager.SignInAsync(user, false, false);
                    return RedirectToRoute(new { }); // here is registration redirection
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}