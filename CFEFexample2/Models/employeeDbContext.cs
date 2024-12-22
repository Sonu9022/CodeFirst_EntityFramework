using Microsoft.EntityFrameworkCore;

namespace CFEFexample2.Models
{
    public class employeeDbContext : DbContext
    {
        public employeeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; } 
    }
}
