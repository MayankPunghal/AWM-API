using System.ComponentModel.DataAnnotations;

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

}
