using System;
using System.ComponentModel.DataAnnotations;

namespace ShareYourself.WebUI.Models
{
    public class EditUserProfileViewModel
    {
        [MinLength(2, ErrorMessage = "Length must be greater than 2"), MaxLength(100, ErrorMessage = "Length must be less than 100")]
        public string Name { set; get; }

        [MinLength(2, ErrorMessage = "Length must be greater than 2"), MaxLength(100, ErrorMessage = "Length must be less than 100")]
        public string Surname { set; get; }

        [MaxLength(144, ErrorMessage = "Length must be less than 144")]
        public string Status { set; get; }

        public string Gender { set; get; }
        public DateTime? BirthDay { set; get; }
    }
}