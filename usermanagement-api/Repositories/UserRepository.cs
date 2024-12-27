using Microsoft.EntityFrameworkCore;
using usermanagement_api.Context;
using usermanagement_api.DTOs;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;

namespace usermanagement_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<usermaster> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _context.usermasters.FirstOrDefaultAsync(u => u.username == username);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task AddUserAsync(usermaster user)
        {
            try
            {
                _context.usermasters.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
        public async Task<PaginatedResultDto> GetUsersListPaginationAsync(int page, int size)
        {
            var skip = (page - 1) * size;
            var totalUsers = await _context.usermasters.CountAsync();
            try
            {
                var users = await _context.usermasters.Skip(skip)
            .Take(size)
            .ToListAsync();

                var userList = users.Select(u => new UserListResponseDto
                {
                    UserId = u.profileid,
                    Username = u.username,
                    Email = u.emailid,
                    FirstName = u.firstname,
                    LastName = u.lastname,
                    DisplayName = u.displayname,
                    ContactNo = u.contactno
                }).ToList();

                return new PaginatedResultDto
                {
                    TotalCount = totalUsers,
                    Users = userList
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
