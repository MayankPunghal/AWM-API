using System.ComponentModel.DataAnnotations;
using usermanagement_api.Models;

namespace usermanagement_api.DTOs
{
    public class UserDTOs
    {
    }
    public class LoggedInUserDetails
    {
        [Required]
        public int LoggedInProfileId { get; set; }
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
        public string ContactNo { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

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


    public class UserListResponseDto : LoggedInUserDetails
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string ContactNo { get; set; }

    }

    public class UserDetailsResponseDto : LoggedInUserDetails
    {
        public int profileid { get; set; }

        public string username { get; set; } = null!;

        public string firstname { get; set; } = null!;

        public string? middlename { get; set; }

        public string? lastname { get; set; }

        public string displayname { get; set; } = null!;

        public string contactno { get; set; } = null!;

        public string? contactno1 { get; set; }

        public string addressline1 { get; set; } = null!;

        public string? addressline2 { get; set; }

        public string? addressline3 { get; set; }

        public string city { get; set; } = null!;

        public string? state { get; set; }

        public string? district { get; set; }

        public string? town { get; set; }

        public string country { get; set; } = null!;

        public string zipcode { get; set; } = null!;

        public int? managerid { get; set; }

        public string? managername { get; set; }

        public string? emailid { get; set; }
        public DateTime lastupdated { get; set; }
        public string updatedby { get; set; }
    }
    public class UserEditDto : LoggedInUserDetails
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        [Required]
        public string DisplayName { get; set; } = null!;
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
