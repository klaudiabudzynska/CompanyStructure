using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models
{
    public class EmployeeItem
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
