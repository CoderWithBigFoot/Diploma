namespace ShareYourself.Business.Dto
{
    public class UserPostDto : UserPostCreationDto
    {
        public int Id { set; get; }

        public UserProfileInfoForPostDto Creator;
    }
}
