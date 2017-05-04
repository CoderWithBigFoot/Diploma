using System;

namespace ShareYourself.Business.Dto
{
    public class UserPostCreationDto
    {
        public string Content { set; get; }
        public DateTime CreationDate { set; get; }
        public int CreatorId { set; get; }
    }
}
