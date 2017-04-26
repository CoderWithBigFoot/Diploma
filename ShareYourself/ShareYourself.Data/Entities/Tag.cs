using System.Collections.Generic;
using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public class Tag : Entity
    {
        public string Name { set; get; }

        public virtual ICollection<UserPost> Posts { set; get; } = new List<UserPost>();
    }
}
