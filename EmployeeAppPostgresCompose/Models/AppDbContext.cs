using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Models
{
    /// <summary>
    /// The Entity Framework Core database context used by the application. It
    /// defines the <see cref="DbSet{TEntity}"/> properties that represent the
    /// tables within the database. In this case there is a single table
    /// represented by the <see cref="Employees"/> property.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;
    }
}