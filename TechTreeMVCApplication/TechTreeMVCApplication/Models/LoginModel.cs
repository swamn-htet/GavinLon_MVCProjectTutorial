using System.ComponentModel.DataAnnotations;

namespace TechTreeMVCApplication.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100,MinimumLength =2)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Keep me Logged in")]
        public bool RememberMe { get; set; }
        public string LoginInValid { get; set; }
    }
}
