using System;

namespace ShareYourself.Business.Dto
{
    public class UserProfileDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public string Status { set; get; }
        public bool? IsMale { set; get; }
    }
}
