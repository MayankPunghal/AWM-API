using Microsoft.AspNetCore.Mvc;
using usermanagement_api.DTOs;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;
using usermanagement_api.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using usermanagement_api.Attributes;
using AWM_API.DTOs;
using System.Diagnostics;

namespace usermanagement_api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // Endpoint for getting the list of users
        [Route(ApiRoute.users.getusers)]
        [AllowAnonymousToken]
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string searchText = "")
        {
            if (page <= 0 || size <= 0)
            {
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Page and size must be greater than 0.",
                });
            }
            try
            {
                var users = await _userService.GetAllUsersAsync(page,size,searchText);
                return Ok(new ApiResponseDto<object>
                {
                    Success = true,
                    Message = "Users fetched successfully.",
                    Result = users,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching users: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //// Endpoint for getting user details by ID
        [Route(ApiRoute.users.getuserbyid)]
        [AllowAnonymousToken]
        [HttpGet()]
        public async Task<IActionResult> GetUserById([FromQuery] long id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id); // Call the service to fetch user by ID
                if (user == null)
                {
                    return NotFound(new ApiResponseDto<object>
                    {
                        Success = false,
                        Message = "User not found."
                    });
                }

                return Ok(new ApiResponseDto<object>
                {
                    Success = true,
                    Message = "User fetched successfully.",
                    Result = user,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching user: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Endpoint for creating a new user
        [Route(ApiRoute.users.createuser)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequestDto userCreateDto)
        {
            if (userCreateDto == null)
            {
                _logger.LogError("Request body could not be deserialized into UserCreateDto");
                return BadRequest(new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Invalid request body.",
                    Result = null
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
                    Result = errors
                });
            }

            try
            {
                var user = new usermaster
                {
                    username = userCreateDto.Username,
                    emailid = userCreateDto.UserEmail,
                    password = userCreateDto.Password.HashPassword(),
                    firstname = userCreateDto.FirstName,
                    lastname = userCreateDto.LastName,
                    displayname = userCreateDto.DisplayName,
                    contactno = userCreateDto.ContactNo.ToString(),
                    createddate = DateTime.UtcNow,
                    lastupdated = DateTime.UtcNow,
                    addressline1 = userCreateDto.AddressLine1,
                    zipcode = userCreateDto.ZipCode,
                    city = userCreateDto.City,
                    country = userCreateDto.Country,
                    updatedby = "4",
                    createdby = "4"
                };

                await _userService.RegisterAsync(user);
                return Ok(new ApiResponseDto<object>
                {
                    Success = true,
                    Message = "User fetched successfully.",
                    Result = user,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating user: {ex.Message}");
                return StatusCode(500, new ApiResponseDto<object>
                {
                    Success = false,
                    Message = "Internal server error. Please try again later.",
                    Result = null
                });
            }
        }

        // Endpoint for editing an existing user
        [Route(ApiRoute.users.edituser)]
        [HttpPost()]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserEditDto userEditDto)
        {
            if (userEditDto == null)
            {
                _logger.LogError("Request body could not be deserialized into UserEditDto");
                return BadRequest("Invalid request body.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                _logger.LogError($"Model validation failed: {string.Join(", ", errors)}");
                return BadRequest(errors);
            }

            try
            {
                await _userService.UpdateUserAsync(userEditDto,id);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while editing user: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
