﻿using System;
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
        private ITagService _tagService;

        public PostController(IUserProfileService userProfileService, IUserPostService userPostService, ITagService tagService)
        {
            _userProfileService = userProfileService;
            _userPostService = userPostService;
            _tagService = tagService;
        }

        [HttpPost]
        public ActionResult CreatePost(string tags, string content) // It should returns the partial view with created post content 
        {
            if(content.Length == 0 || string.IsNullOrEmpty(content))
            {
                return null;
            }

            char[] separators = new char[]
            {
                ',', '.', '/', '*', '-', '+', '!', '@', '#', '№', '$', '%', '^', '&', '(', ')', ':', ';', ' ',
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '{', '}', '[', ']'
            };
            
            ICollection<TagDto> tagDtos = new List<TagDto>();
            string formattedTag;

            foreach(var currentElement in tags.Split(separators))
            {
                if (!string.IsNullOrEmpty(currentElement))
                {
                    if (currentElement != "_")
                    {
                        formattedTag = currentElement.Substring(0, 1).ToUpper() + currentElement.Substring(1).ToLower();
                        tagDtos.Add(new TagDto
                        {
                            Name = formattedTag
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

        [HttpGet]
        public ActionResult TagCloud()
        {
           /* var tags = _tagService
                .Get<TagDto>();

            var result = Mapper.Map<IEnumerable<string>>(tags);
            */
            var fakeResult = new List<string>
            {
                "First", "sec", "asdas", "asdasd", "asdfasd", "asdafasd", "ghdsg", "jdf", "t", "ghsdfsdf", "kfgfbxd"
            };

            return View("TagCloud", fakeResult);
        }
    }
}