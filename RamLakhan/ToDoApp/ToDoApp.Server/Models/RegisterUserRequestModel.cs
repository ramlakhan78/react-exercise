using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Server.Models
{
    public class RegisterUserRequestModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Username must be minimum 6 characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be minimum 6 characters long", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Phone number must be between 10 and 15 characters long.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }
    }
}
