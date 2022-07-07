namespace CompanyStructure.Models.Employee
{
    public class EmployeeReadOnlyDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
