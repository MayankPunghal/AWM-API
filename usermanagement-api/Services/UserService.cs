using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;
using usermanagement_api.Utilities;

namespace usermanagement_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || user.password != password.HashPassword())
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
    }
}
