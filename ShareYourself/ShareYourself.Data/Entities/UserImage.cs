using GenericRepository.Data.EntityFramework;

namespace ShareYourself.Data.Entities
{
    public class UserImage : Entity
    {
        public string MimeType { set; get; }
        public byte[] Content { set; get; }

        public virtual UserProfile Creator { set; get; }
    }
}
