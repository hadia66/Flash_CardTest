using Flash_Card.Entity;
using Microsoft.EntityFrameworkCore;
namespace Flash_Card
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomField>()
                .HasKey(c => c.CustomId);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomField> Fields { get; set; }
    }
}
