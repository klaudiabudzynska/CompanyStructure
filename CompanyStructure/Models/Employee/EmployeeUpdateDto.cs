﻿using System.ComponentModel.DataAnnotations;

namespace CompanyStructure.Models.Employee
{
    public class EmployeeUpdateDto : BaseDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public int RoleId { get; set; }
        public int SupervisorId { get; set; }
    }
}
