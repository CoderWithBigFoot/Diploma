using System;
using ShareYourself.Data.Entities;

namespace ShareYourself.Business.Dto
{
    public class UserProfileDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public Gender? Gender { set; get; }
        DateTime? BirthDate { set; get; }
    }
}
