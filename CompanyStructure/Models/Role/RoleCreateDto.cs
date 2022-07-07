using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Role
{
    public class RoleCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
