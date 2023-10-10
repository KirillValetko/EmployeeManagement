using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.DAL.Infrastructure.ModelConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FullName).IsRequired();
            builder.Property(e => e.SpecialtyId).IsRequired();
            builder.HasOne(e => e.Specialty)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SpecialtyId);
            builder.HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<User>(u => u.EmployeeId)
                .IsRequired();
        }
    }
}
