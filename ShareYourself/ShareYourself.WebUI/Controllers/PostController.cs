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
    public class PostController : Controller
    {
        private IUserProfileService _userProfileService;
        private IUserPostService _userPostService;

        public PostController(IUserProfileService userProfileService, IUserPostService userPostService)
        {
            _userProfileService = userProfileService;
            _userPostService = userPostService;
        }

        [HttpPost]
        public ActionResult CreatePost(string tags, string content) // It should returns the partial view with created post content 
        {
            char[] separators = new char[]
            {
                ',', '.', '/', '*', '-', '+', '!', '@', '#', '№', '$', '%', '^', '&', '(', ')', ':', ';', ' '
            };
            
            tags.Split(separators);

            UserPostCreationDto dto = new UserPostCreationDto
            {
                Content = content,
                CreationDate = DateTime.Now,
                CreatorId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id
            };

            _userPostService.Create(dto);
            
            return RedirectToRoute(new { controller = "Profile", action = "ProfilePage"});
        }
    }
}