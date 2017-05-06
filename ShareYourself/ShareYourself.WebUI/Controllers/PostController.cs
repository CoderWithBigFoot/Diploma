using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
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
        private string _errorView = "~/Views/Shared/Error.cshtml";
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

            try
            {
                var userId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id;

                UserPostCreationDto dto = new UserPostCreationDto
                {
                    Content = content,
                    CreationDate = DateTime.Now,
                    CreatorId = userId
                };

                dto.Tags = tagDtos;

                _userPostService.Create(dto);

                var createdPostDto = _userPostService.Take(userId, 0, 1);
                var createdPostViewModel = Mapper.Map<IEnumerable<UserPostViewModel>>(createdPostDto);

                return PartialView("~/Views/Shared/PostPartial.cshtml", createdPostViewModel);
            }
            catch (Exception ex)
            {
                return View(_errorView, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetPosts(int userId, int skip, int count = 5)
        {
            var userPostDtos = _userPostService.Take(userId, skip, count);

            if(userPostDtos.Count() == 0)
            {
                return null;
            }

            var userPostViewModels = Mapper.Map<IEnumerable<UserPostViewModel>>(userPostDtos);

            return PartialView("~/Views/Shared/PostPartial.cshtml", userPostViewModels);
        }
    }
}