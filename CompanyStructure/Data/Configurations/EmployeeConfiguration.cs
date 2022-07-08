using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyStructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Employees_ToTable");
        }
    }
}
