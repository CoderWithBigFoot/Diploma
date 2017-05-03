namespace ShareYourself.Business.Dto
{
    public class UserProfileAvatarEditingDto
    {
        /// <summary>
        /// UserProfile Id
        /// </summary>
        public int UserProfileId  { set; get; }
        public string MimeType { set; get; }
        public byte[] Content { set; get; }
    }
}
