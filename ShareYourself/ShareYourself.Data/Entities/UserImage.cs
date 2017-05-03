using System.Collections.Generic;
using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public class UserImage : Entity
    {
        public string MimeType { set; get; }
        public byte[] Content { set; get; }

        public virtual ICollection<UserProfile> Owners { set; get; } = new List<UserProfile>();
    }
}
