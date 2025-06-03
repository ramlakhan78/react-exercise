using ToDoApp.Server.Models;

namespace ToDoApp.Server.Contracts
{
    public interface IAuthService
    {
        /// <summary>
        /// Validates the user credentials and returns a JWT token if valid.
        /// </summary>
        /// <param name="model">The model has username and password of the user.</param>
        /// <returns>A JWT token if the credentials are valid; otherwise, null.</returns>
        ResponseModel AuthenticateAsync(LoginRequestModel model);

        /// <summary>
        /// Registers a new user with the provided username and password.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <returns>True if registration is successful; otherwise, false.</returns>
        Task<bool> RegisterAsync(string username, string password);
    }
}
