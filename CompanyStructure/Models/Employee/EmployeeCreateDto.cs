using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public int RoleId { get; set; }

    }
}
