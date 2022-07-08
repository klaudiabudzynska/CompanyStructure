using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Role
{
    public class EmployeeRoleCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
