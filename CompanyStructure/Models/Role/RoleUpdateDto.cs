using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Role
{
    public class RoleUpdateDto : BaseDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
