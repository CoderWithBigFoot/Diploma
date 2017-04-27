namespace ShareYourself.Data.Entities
{
    public class UserImage
    {
        public int Id { set; get; }
        public string MimeType { set; get; }
        public byte[] Content { set; get; }

        public virtual UserProfile Creator { set; get; }
    }
}
