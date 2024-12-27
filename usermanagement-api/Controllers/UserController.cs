using Microsoft.AspNetCore.Mvc;
using usermanagement_api.DTOs;
using usermanagement_api.Interfaces;
using usermanagement_api.Models;
using usermanagement_api.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using usermanagement_api.Attributes;

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
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            if (page <= 0 || size <= 0)
            {
                return BadRequest("Page and size must be greater than 0.");
            }
            try
            {
                var users = await _userService.GetAllUsersAsync(page,size);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching users: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //// Endpoint for getting user details by ID
        //[Route(ApiRoute.users.getuserbyid)]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById(long id)
        //{
        //    try
        //    {
        //        var user = await _userService.GetUserByIdAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound("User not found.");
        //        }

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error while fetching user: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}

        //// Endpoint for creating a new user
        //[Route(ApiRoute.users.createuser)]
        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        //{
        //    if (userCreateDto == null)
        //    {
        //        _logger.LogError("Request body could not be deserialized into UserCreateDto");
        //        return BadRequest("Invalid request body.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        //        _logger.LogError($"Model validation failed: {string.Join(", ", errors)}");
        //        return BadRequest(errors);
        //    }

        //    try
        //    {
        //        var user = new usermaster
        //        {
        //            username = userCreateDto.Username,
        //            emailid = userCreateDto.UserEmail,
        //            password = userCreateDto.Password.HashPassword(),
        //            firstname = userCreateDto.FirstName,
        //            lastname = userCreateDto.LastName,
        //            displayname = userCreateDto.DisplayName,
        //            contactno = userCreateDto.ContactNo.ToString(),
        //            createddate = DateTime.UtcNow,
        //            lastupdated = DateTime.UtcNow,
        //            updateby = "4",
        //            createdby = "4",
        //            addressline1 = userCreateDto.AddressLine1,
        //            zipcode = userCreateDto.ZipCode,
        //            city = userCreateDto.City,
        //            country = userCreateDto.Country
        //        };

        //        await _userService.RegisterAsync(user);
        //        return Ok("User created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error while creating user: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}

        //// Endpoint for editing an existing user
        //[Route(ApiRoute.users.edituser)]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> EditUser(long id, [FromBody] UserEditDto userEditDto)
        //{
        //    if (userEditDto == null)
        //    {
        //        _logger.LogError("Request body could not be deserialized into UserEditDto");
        //        return BadRequest("Invalid request body.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        //        _logger.LogError($"Model validation failed: {string.Join(", ", errors)}");
        //        return BadRequest(errors);
        //    }

        //    try
        //    {
        //        var existingUser = await _userService.GetUserByIdAsync(id);
        //        if (existingUser == null)
        //        {
        //            return NotFound("User not found.");
        //        }

        //        existingUser.username = userEditDto.Username;
        //        existingUser.emailid = userEditDto.UserEmail;
        //        existingUser.password = userEditDto.Password.HashPassword();
        //        existingUser.firstname = userEditDto.FirstName;
        //        existingUser.lastname = userEditDto.LastName;
        //        existingUser.displayname = userEditDto.DisplayName;
        //        existingUser.contactno = userEditDto.ContactNo.ToString();
        //        existingUser.lastupdated = DateTime.UtcNow;
        //        existingUser.updateby = "4"; // The ID of the current user performing the update (this could be dynamic)

        //        await _userService.UpdateUserAsync(existingUser);
        //        return Ok("User updated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error while editing user: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}
    }
}
