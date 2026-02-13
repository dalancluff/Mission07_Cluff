using Microsoft.EntityFrameworkCore;

namespace Mission06_Cluff.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Optional: Add any additional configuration here
            // For example, you could set default values or add indexes
        }
    }
}