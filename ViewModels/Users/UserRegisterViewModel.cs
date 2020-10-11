using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.ViewModels.Users
{
    public class UserRegisterViewModel
    {
        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
