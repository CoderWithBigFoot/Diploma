using System;

namespace ShareYourself.WebUI.Models
{
    public class UserProfileHomeViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public string Status { set; get; }
        public bool? IsMale { set; get; }
        public DateTime RegistrationDate { set; get; }
    }
}