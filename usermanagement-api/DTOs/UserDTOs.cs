using System.ComponentModel.DataAnnotations;
using usermanagement_api.Models;

namespace usermanagement_api.DTOs
{
    public class UserDTOs
    {
    }
    public class UserRegisterRequestDto
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string DisplayName { get; set; } = null!;
        [Required]
        public int ContactNo { get; set; }

    }

    public class UserLoginRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }

    }

    public class PaginatedResultDto
    {
        public int TotalCount { get; set; }
        public List<UserListResponseDto> Users { get; set; }
    }


    public class UserListResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string ContactNo { get; set; }

    }
}
