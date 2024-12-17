using Due_Diligence.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Scraping.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options) { }


        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Person>().ToTable("Person");

            base.OnModelCreating(modelBuilder);
        }
    }
}
