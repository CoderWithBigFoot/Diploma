using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using AutoMapper;
using ShareYourself.WebUI.Models;
using ShareYourself.WebUI.Identity.Models;
using ShareYourself.Business;
using ShareYourself.Business.Dto;

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
                case SignInStatus.Success: return RedirectToRoute(new { controller = "UserProfile", action = "ProfilePage" }); // here is login page
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
                        var userDto = Mapper.Map<UserProfileRegistrationDto>(model);
                        userDto.Name = userDto.Name.Substring(0, 1).ToUpper() + userDto.Name.Substring(1).ToLower();
                        userDto.Surname = userDto.Surname.Substring(0, 1).ToUpper() + userDto.Surname.Substring(1).ToLower();
                        userDto.RegistrationDate = DateTime.Now;
                        _userProfileService.Create(userDto);
                    }
                    catch(Exception ex)
                    {
                        ModelState.AddModelError("", $"Sorry, service cannot create a new profile {ex.Message}");
                        await UserManager.DeleteAsync(user);
                        return View(model);
                    }
                    await SignInManager.SignInAsync(user, false, false);
                    return RedirectToRoute(new { controller = "UserProfile", action = "ProfilePage"}); // here is registration redirection
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