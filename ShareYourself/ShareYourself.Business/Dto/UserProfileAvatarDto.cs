namespace ShareYourself.Business.Dto
{
    public class UserProfileAvatarDto
    {
        public int UserProfileId { set; get; }
        public string MimeType { set; get; }
        public byte[] Content { set; get; }
    }
}
