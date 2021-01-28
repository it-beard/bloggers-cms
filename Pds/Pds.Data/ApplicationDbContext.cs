using Pds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Enums;

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
            modelBuilder.Entity<Person>()
                .Property(b => b.Status)
                .HasDefaultValue(PersonStatus.Active);
        }
    }
}