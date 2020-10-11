using System.ComponentModel.DataAnnotations;

namespace Andreys.ViewModels.Users
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
