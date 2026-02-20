using Microsoft.EntityFrameworkCore;

namespace MIssion07_Cluff.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map to existing table names in the SQLite database
            modelBuilder.Entity<Application>().ToTable("Movies");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}