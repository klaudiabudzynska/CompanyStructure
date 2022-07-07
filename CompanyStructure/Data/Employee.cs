using System;
using System.Collections.Generic;

namespace CompanyStructure.Data
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }

        public static implicit operator Employee(List<Employee> v)
        {
            throw new NotImplementedException();
        }
    }
}
