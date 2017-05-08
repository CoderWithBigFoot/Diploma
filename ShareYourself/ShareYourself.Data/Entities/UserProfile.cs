using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public class UserProfile : Entity
    {
        public string Email { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public bool? IsMale { set; get; }
        public string Status { set; get; }
        public DateTime RegistrationDate { set; get; }

        public int? AvatarId { set; get; }

        [ForeignKey("AvatarId")]
        public virtual UserImage Avatar { set; get; }

        public virtual ICollection<UserPost> Publications { set; get; } = new List<UserPost>();//
        public virtual ICollection<UserPost> Likes { set; get; } = new List<UserPost>();//

        public virtual ICollection<UserProfile> Subscriptions { set; get; } = new List<UserProfile>(); // me on who
        public virtual ICollection<UserProfile> Followers { set; get; } = new List<UserProfile>(); // on me
    }
}
