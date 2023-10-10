using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.DAL.Infrastructure.ModelConfigurations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SpecialtyName).IsRequired();
        }
    }
}
