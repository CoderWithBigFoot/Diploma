using System;
using System.Collections.Generic;

namespace ShareYourself.WebUI.Models
{
    public class UserPostViewModel
    {
        public int Id { set; get; }
        public string Content { set; get; }
        public DateTime CreationDate { set; get; }
        public int CreatorId { set; get; }

        public UserProfileInfoForPostViewModel Creator { set; get; }
        public ICollection<string> Tags { set; get; }
    }
}