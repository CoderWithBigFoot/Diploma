using System.ComponentModel.DataAnnotations;

namespace ShareYourself.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { set; get; }

        [Required]
        [MinLength(2),MaxLength(100)]
        public string Surname { set; get; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}