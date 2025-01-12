using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using usermanagement_api.DTOs;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;
using usermanagement_api.Utilities;

namespace usermanagement_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public UserService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null || user.password.VerifyPassword(password.HashPassword()))
            throw new UnauthorizedAccessException("Invalid credentials.");

        var claims = new[]
        {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "")
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task RegisterAsync(usermaster user)
    {
        try
        {
            if (await _userRepository.GetUserByUsernameAsync(user.username) != null)
                throw new InvalidOperationException("User already exists.");
            user.password = user.password.HashPassword();
            user.rcreate = DateTime.UtcNow;
            await _userRepository.AddUserAsync(user);
        }
        catch (Exception ex)
        {

        }
    }
    public async Task<PaginatedResultDto> GetAllUsersAsync(int page, int size, string searchText)
    {
        try
        {
            var paginatedUserList = await _userRepository.GetUsersListPaginationAsync(page, size, searchText);
            return paginatedUserList;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while fetching users: {ex.Message}");
            throw new Exception("Error while fetching users.");
        }
    }

    public async Task<UserDetailsResponseDto> GetUserByIdAsync(long id)
    {
        try
        {
            var userDetails =  await _userRepository.GetUserByIdAsync(id);
            return new UserDetailsResponseDto
            {
                profileid = userDetails.profileid,
                username = userDetails.username,
                firstname = userDetails.firstname,
                middlename = userDetails.middlename,
                lastname = userDetails.lastname,
                displayname = userDetails.displayname,
                emailid = userDetails.emailid,
                contactno = userDetails.contactno,
                contactno1 = userDetails.contactno1,
                addressline1 = userDetails.addressline1,
                addressline2 = userDetails.addressline2,
                addressline3 = userDetails.addressline3,
                town = userDetails.town,
                district = userDetails.district,
                city = userDetails.city,
                state = userDetails.state,
                country = userDetails.country,
                zipcode = userDetails.zipcode,
                managerid = userDetails.managerid,
                managername = userDetails.managername               
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching user", ex);
        }
    }
}
