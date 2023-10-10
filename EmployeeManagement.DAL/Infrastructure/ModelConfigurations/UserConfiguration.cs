using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.DAL.Infrastructure.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.AccountName).IsRequired();
            builder.Property(u => u.Role).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.EmployeeId).IsRequired();
            builder.HasIndex(u => u.AccountName).IsUnique();
        }
    }
}
