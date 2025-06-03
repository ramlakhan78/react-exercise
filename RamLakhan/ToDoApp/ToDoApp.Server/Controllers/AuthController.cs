using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Server.Contracts;
using ToDoApp.Server.Models;

namespace ToDoApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        #region [Sign In]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult login(LoginRequestModel model) => Ok(authService.AuthenticateAsync(model));
        #endregion [sign Out]
    }
}
