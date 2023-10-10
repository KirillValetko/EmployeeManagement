using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Infrastructure
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
