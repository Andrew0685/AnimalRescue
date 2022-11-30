using AnimalRescueDBModels.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnimalRescue.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Role { get; set; }
    }

    //public enum Role
    //{
    //    User,
    //    Admin
    //}
}
