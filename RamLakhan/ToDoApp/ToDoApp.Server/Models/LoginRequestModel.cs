using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Server.Models
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage ="UserName is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
