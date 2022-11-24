using System.ComponentModel.DataAnnotations;

namespace AnimalRescue.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
