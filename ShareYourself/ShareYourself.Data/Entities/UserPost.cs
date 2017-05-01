using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public class UserPost : Entity
    {
        public string Content { set; get; }
        public DateTime? CreationDate { set; get; }

        public int CreatorId { set; get; }

        [ForeignKey("CreatorId")]
        public virtual UserProfile Creator { set; get; }//
        public virtual ICollection<Tag> Tags { set; get; } = new List<Tag>(); //

        /*public virtual ICollection<UserProfile> Likes { set; get; } = new List<UserProfile>();//
        public virtual ICollection<UserProfile> Reposts { set; get; } = new List<UserProfile>();//*/
    }
}
