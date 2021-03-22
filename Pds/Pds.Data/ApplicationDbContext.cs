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
        public DbSet<Content> Contents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Channel> Channels { get; set; }

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

            modelBuilder.Entity<Content>()
                .Property(b => b.SocialMediaType)
                .HasDefaultValue(SocialMediaType.YouTube);
            
            modelBuilder.Entity<Content>()
                .HasOne(a => a.Order)
                .WithOne(a => a.Content)
                .HasForeignKey<Order>(c => c.ContentId);
        }
    }
}