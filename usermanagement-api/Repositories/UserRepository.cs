using Microsoft.EntityFrameworkCore;
using usermanagement_api.Context;
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

                throw;
            }
        }
    }
}
