using Pds.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pds.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UpdateStructure(builder);
            base.OnModelCreating(builder);
        }

        private void UpdateStructure(ModelBuilder modelBuilder)
        {
            // Place for specific fluent properties
        }
    }
}