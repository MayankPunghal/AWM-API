using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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
        public async Task<PaginatedResultDto> GetUsersListPaginationAsync(int page, int size, string searchText)
        {
            var skip = (page - 1) * size;
            try
            {
                var query = _context.usermasters.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var searchableColumns = new List<string> { "username", "emailid", "firstname", "lastname", "displayname", "contactno" };

                    // Build a predicate dynamically
                    var parameter = Expression.Parameter(typeof(usermaster), "user");
                    Expression? predicate = null;

                    foreach (var column in searchableColumns)
                    {
                        var property = Expression.Property(parameter, column);
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                        var searchTextExpression = Expression.Constant(searchText);
                        var containsExpression = Expression.Call(property, containsMethod, searchTextExpression);

                        predicate = predicate == null
                            ? (Expression)containsExpression
                            : Expression.OrElse(predicate, containsExpression);
                    }

                    var lambda = Expression.Lambda<Func<usermaster, bool>>(predicate!, parameter);
                    query = query.Where(lambda);
                }

                var totalRecords = await query.CountAsync();

                var users = await query
                    .OrderBy(user => user.profileid)
                    .Skip(skip)
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
                    TotalCount = totalRecords,
                    Users = userList
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<PaginatedResultDto> GetUsersListPaginationAsync_bak(int page, int size, string searchText)
        {
            var skip = (page - 1) * size;
            try
            {
                var query = _context.usermasters.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var searchableColumns = new List<string> { "username", "emailid", "firstname", "lastname", "displayname", "contactno" };
                    query = query.Where(user =>
                        searchableColumns.Any(column => EF.Property<string>(user, column).Contains(searchText)));
                }
                //var users = await _context.usermasters.OrderBy(el => el.profileid).Skip(skip)
                //.Take(size)
                //.ToListAsync();
                var totalRecords = await query.CountAsync();

                var users = await query
                            .OrderBy(user => user.profileid)
                            .Skip(skip)
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
                    TotalCount = totalRecords,
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
