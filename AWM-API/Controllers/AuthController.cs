using Microsoft.AspNetCore.Mvc;
using usermanagement_api.Attributes;
using usermanagement_api.DTOs;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;
using usermanagement_api.Utilities;

namespace usermanagement_api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [Route(ApiRoute.users.registeruser)]
        [HttpPost]
        [AllowAnonymousToken]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto? userRegisterDto)
        {
            if (userRegisterDto == null)
            {
                _logger.LogError("Request body could not be deserialized into UserRegisterRequestDto");
                return BadRequest("Invalid request body.");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                _logger.LogError($"Model validation failed: {string.Join(", ", errors)}");
                return BadRequest(errors);
            }

            var user = new usermaster
            {
                username = userRegisterDto.Username,
                emailid = userRegisterDto.UserEmail,
                password = userRegisterDto.Password.HashPassword(),
                rcreate = DateTime.UtcNow,
                firstname = userRegisterDto.FirstName,
                lastname = userRegisterDto.LastName,
                displayname = userRegisterDto.DisplayName,
                contactno = userRegisterDto.ContactNo.ToString(),
                createddate = DateTime.UtcNow,
                lastupdated = DateTime.UtcNow,
                updateby = "4",
                createdby = "4",
                addressline1 = "asdfasdf",
                zipcode = "201304",
                city = "Noida",
                country = "India"
            };
            await _userService.RegisterAsync(user);
            return Ok("User registered successfully.");
        }

        [Route(ApiRoute.users.loginbyusername)]
        [HttpPost]
        [AllowAnonymousToken]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginDto)
        {
            var token = await _userService.AuthenticateAsync(userLoginDto.username, userLoginDto.password);
            return Ok(new { Token = token });
        }
    }
}
