using System;
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
        private string _postParital = "~/Views/Shared/PostPartial.cshtml";
        private IUserProfileService _userProfileService;
        private IUserPostService _userPostService;
        private ITagService _tagService;

        private void InitLikesInUserPostViewModel(IEnumerable<UserPostViewModel> collection)
        {
            foreach(var current in collection)
            {
                current.Likes = _userPostService.Likes(current.Id);
            }
        }

        public PostController(IUserProfileService userProfileService, IUserPostService userPostService, ITagService tagService)
        {
            _userProfileService = userProfileService;
            _userPostService = userPostService;
            _tagService = tagService;
        }

        [HttpPost]
        public ActionResult CreatePost(string tags, string content)  
        {
            if(content.Length == 0 || 
                string.IsNullOrEmpty(content) || 
                content.Length >= 1000 || 
                string.IsNullOrEmpty(tags) ||
                tags.Length == 0)
            {
                return null;
            }
         
            if(content != null)
            {
                if(!content.Any(x => char.IsLetter(x))){
                    return null;
                }
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
                    if (currentElement.Length >= 40)
                    {
                        return null;
                    }

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

            if(tagDtos.Count > 5 || tagDtos.Count < 1)
            {
                return null;
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

                return PartialView(_postParital, createdPostViewModel);
            }
            catch (Exception ex)
            {
                return View(_errorView, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetPosts(int userId, int skip, int count = 5)
        {
            if(skip < 0 || count < 0)
            {
                return PartialView(_errorView, "There are no such posts.");
            }

            var userPostDtos = _userPostService.Take(userId, skip, count);

            if(userPostDtos.Count() == 0)
            {
                return null;
            }

            var userPostViewModels = Mapper.Map<IEnumerable<UserPostViewModel>>(userPostDtos);
            InitLikesInUserPostViewModel(userPostViewModels);

            return PartialView(_postParital, userPostViewModels);
        }

        [HttpGet]
        [ActionName("GetPostsByTag")]
        public ActionResult GetPosts(string tag, int skip = 0, int count = 4)
        {
            if (!_tagService.Contains(tag) || skip < 0 || count < 0)
            {
                return PartialView("Error", "Such tag doesn't exist.");
            }

            var postDtos = _userPostService.Take(
                tagDto: new TagDto { Name = tag },
                skip: skip,
                count: count
                );

            var result = Mapper.Map<IEnumerable<UserPostViewModel>>(postDtos);
            InitLikesInUserPostViewModel(result);

            return PartialView(_postParital, result);
        }

        [HttpGet]
        [ActionName("GetPostsByFilter")]
        public ActionResult GetPostsBy(string filter, int skip = 0, int count = 4)
        {
            int a = 1;
            PostFilters castedFilter;
            try
            {
                 castedFilter = (PostFilters)Enum.Parse(typeof(PostFilters), filter, true);
            }
            catch(Exception)
            {
                return null;
            }
            var userId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id;

            var result = _userPostService.Take(
                filter: castedFilter,
                userId: userId,
                skip: skip,
                count: count);

            var mappedResult = Mapper.Map<IEnumerable<UserPostViewModel>>(result);
            InitLikesInUserPostViewModel(mappedResult);

            return PartialView(_postParital, mappedResult); ;
        }

        [HttpGet]
        public ActionResult Posts(string filter)
        {
            PostFilters castedFilter;
            try
            {
                castedFilter = (PostFilters)Enum.Parse(typeof(PostFilters), filter, true);
            }
            catch (Exception)
            {
                return null;
            }
            int a = 1;
            return View("Posts", castedFilter);
        }

        [HttpGet]
        public ActionResult TagPosts(string tag)
        {
            int a = 1;
            if (!_tagService.Contains(tag))
            {
                return PartialView("Error", "Such tag doesn't exist.");
            }

            return View(viewName: "TagPosts", model: tag);
        }

        [HttpGet]
        public ActionResult TagCloud()
        {
            var tags = _tagService
                .Get<TagDto>();

            var result = Mapper.Map<IEnumerable<string>>(tags);
            
            return View("TagCloud", result);
        }

        [HttpPost]
        public object Like(int postId)
        {
            var userId = _userProfileService.Get<UserProfileIdDto>(User.Identity.Name).Id;
            _userPostService.SetLike(userId, postId);

            var result = _userPostService.Likes(postId);
            if(result <= 0)
            {
                return "";
            }
            return _userPostService.Likes(postId);
        }
    }
}