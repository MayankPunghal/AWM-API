using usermanagement_api.DTOs;
using usermanagement_api.Models;

namespace usermanagement_api.Interfaces
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task RegisterAsync(usermaster user);
        Task<PaginatedResultDto> GetAllUsersAsync(int page, int size, string searchText);
        Task<UserDetailsResponseDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserEditDto user,int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
