using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Users
{
    public class ApiUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Password is limited to {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
