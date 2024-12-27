using usermanagement_api.DTOs;
using usermanagement_api.Models;

namespace usermanagement_api.Interfaces
{
    public interface IUserRepository
    {
        Task<usermaster> GetUserByUsernameAsync(string username);
        Task AddUserAsync(usermaster user);
        Task<PaginatedResultDto> GetUsersListPaginationAsync(int page, int size);
    }
}
