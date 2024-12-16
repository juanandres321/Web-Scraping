using Microsoft.EntityFrameworkCore;

namespace Web_Scraping.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options) { }


        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Supplier");

            base.OnModelCreating(modelBuilder);
        }
    }
}
