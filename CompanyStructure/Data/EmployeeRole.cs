using System;
using System.Collections.Generic;

namespace CompanyStructure.Data
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
