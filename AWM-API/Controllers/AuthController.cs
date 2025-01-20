using AWM_API.DTOs;
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
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Invalid request body."
                });
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                _logger.LogError($"Model validation failed: {string.Join(", ", errors)}");
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = errors.ToList()
                });
            }

            try
            {
                var user = new usermaster
                {
                    username = userRegisterDto.Username,
                    emailid = userRegisterDto.UserEmail,
                    password = userRegisterDto.Password.HashPassword(),
                    rcreate = DateTime.UtcNow,
                    firstname = userRegisterDto.FirstName,
                    lastname = userRegisterDto.LastName,
                    displayname = userRegisterDto.DisplayName,
                    contactno = userRegisterDto.ContactNo,
                    createddate = DateTime.UtcNow,
                    lastupdated = DateTime.UtcNow,
                    addressline1 = userRegisterDto.AddressLine1,
                    zipcode = userRegisterDto.ZipCode,
                    city = userRegisterDto.City,
                    country = userRegisterDto.Country,
                    updatedby = "4",
                    createdby = "4"
                };
                await _userService.RegisterAsync(user);
                return Ok(new ApiResponseDto<object>
                {
                    Success = true,
                    Message = "User registered successfully.",
                    Result = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while registering user: {ex.Message}");
                return StatusCode(500, new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Internal server error.",
                    Errors = new List<string> { ex.Message }
                });
            }
        }

        [Route(ApiRoute.users.loginbyusername)]
        [HttpPost]
        [AllowAnonymousToken]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginDto)
        {
            try
            {
                var token = await _userService.AuthenticateAsync(userLoginDto.username, userLoginDto.password);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized(new ApiResponseDto<object>
                    {
                        Success = false,
                        Message = "Invalid username or password.",
                        Result = null
                    });
                }
                return Ok(new ApiResponseDto<object>
                {
                    Success = true,
                    Message = "Login successful.",
                    Result = new { Token = token }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during login: {ex.Message}");
                return StatusCode(500, new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Internal server error.",
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}
