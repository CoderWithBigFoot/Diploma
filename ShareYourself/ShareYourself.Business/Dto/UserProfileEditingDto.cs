using System;

namespace ShareYourself.Business.Dto
{
    public class UserProfileEditingDto
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Status { set; get; }
        public bool? IsMale { set; get; }
        public DateTime? BirthDate { set; get; }
    }
}
