using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyStructure.Data.Configurations
{
    public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasData(
                new EmployeeRole
                {
                    Id = 1,
                    Name = "Meneger"
                },
                new EmployeeRole
                {
                    Id = 2,
                    Name = "Team Leader"
                },
                new EmployeeRole
                {
                    Id = 3,
                    Name = "Scrum Master"
                },
                new EmployeeRole
                {
                    Id = 4,
                    Name = "Frontend Developer"
                },
                new EmployeeRole
                {
                    Id = 5,
                    Name = "Backend Developer" +
                    ""
                }
            );
        }
    }
}
