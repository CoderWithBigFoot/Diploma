using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
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
            
            ICollection<TagDto> tagDtos = new List<TagDto>();

            foreach(var currentElement in tags.Split(separators))
            {
                if (!string.IsNullOrEmpty(currentElement))
                {
                    if(currentElement != "_")
                    {
                        tagDtos.Add(new TagDto
                        {
                            Name = currentElement
                        });
                    }
                }
            }  

            UserPostCreationDto dto = new UserPostCreationDto
            {
                Content = content,
                CreationDate = DateTime.Now,
                CreatorId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id
            };

            dto.Tags = tagDtos;

            _userPostService.Create(dto);
            
            return RedirectToRoute(new { controller = "UserProfile", action = "ProfilePage"});
        }
    }
}