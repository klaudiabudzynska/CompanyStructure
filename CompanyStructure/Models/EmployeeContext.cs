using Microsoft.EntityFrameworkCore;

namespace CompanyStructure.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {

        }

        public DbSet<EmployeeItem> EmployeeItems { get; set; } = null!;
    }
}
