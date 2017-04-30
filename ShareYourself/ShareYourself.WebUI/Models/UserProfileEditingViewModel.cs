using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShareYourself.WebUI.Models
{
    public class UserProfileEditingViewModel
    {
        public int Id { set; get; }

        [MinLength(2, ErrorMessage = "Length must be greater than 2"), MaxLength(100, ErrorMessage = "Length must be less than 100")]
        public string Name { set; get; }

        [MinLength(2, ErrorMessage = "Length must be greater than 2"), MaxLength(100, ErrorMessage = "Length must be less than 100")]
        public string Surname { set; get; }

        [MaxLength(144, ErrorMessage = "Length must be less than 144")]
        public string Status { set; get; }

        [Display(Name = "Gender")]
        public bool? IsMale { set; get; }
    }
}