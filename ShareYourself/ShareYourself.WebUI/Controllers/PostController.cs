using System;
using System.Web;
using System.Web.Mvc;
using ShareYourself.WebUI.Models;
using ShareYourself.Business;
using ShareYourself.Business.Dto;
using AutoMapper;

namespace ShareYourself.WebUI.Controllers
{
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
        public void CreatePost(string tags, string content) // It should returns the partial view with created post content 
        {
            int a = 1;
            int b = 2;

        }
    }
}