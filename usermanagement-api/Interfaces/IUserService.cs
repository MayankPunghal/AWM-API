using usermanagement_api.Models;

namespace usermanagement_api.Interfaces
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task RegisterAsync(usermaster user);
    }
}
