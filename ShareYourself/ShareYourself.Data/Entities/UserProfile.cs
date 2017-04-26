using System;
using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public enum Gender { Male = 1, Female = 2 };

    public class UserProfile : Entity
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public Gender? Gender { set; get; }
        public DateTime? BirthDate { set; get; }

       /* public virtual ICollection<UserProfile> Subscriptions { set; get; } = new List<UserProfile>(); // me on who
        public virtual ICollection<UserProfile> Followers { set; get; } = new List<UserProfile>(); // on me*/
    }
}
