namespace CompanyStructure.Data
{
    //TODO: more details
    public partial class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
        public int? SupervisorId { get; set; }

        public virtual EmployeeRole? Role { get; set; }

        public static implicit operator Employee(List<Employee> v)
        {
            throw new NotImplementedException();
        }
    }
}
