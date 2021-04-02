using System;
using System.Collections.Generic;
using Pds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;

namespace Pds.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PersonTopic> PersonTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UpdateStructure(builder);
            SeedDate(builder);
            base.OnModelCreating(builder);
        }

        private void UpdateStructure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(b => b.Status)
                .HasDefaultValue(PersonStatus.Active);

            modelBuilder.Entity<Content>()
                .Property(b => b.SocialMediaType);
            
            modelBuilder.Entity<Content>()
                .HasOne(a => a.Bill)
                .WithOne(a => a.Content)
                .HasForeignKey<Bill>(c => c.ContentId);

            modelBuilder.Entity<PersonTopic>()
                .HasOne(pt => pt.Person)
                .WithMany(p => p.PersonTopics)
                .HasForeignKey(pt => pt.PersonId);

            modelBuilder.Entity<PersonTopic>()
                .HasOne(pt => pt.Topic)
                .WithMany(p => p.PersonTopics)
                .HasForeignKey(pt => pt.TopicId);

            modelBuilder.Entity<PersonTopic>()
                .HasKey(pt => new {pt.TopicId, pt.PersonId});
        }

        private void SeedDate(ModelBuilder builder)
        {
            var brands = new List<Brand>
            {
                new()
                {
                    Id = Guid.Parse("5AA23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                    Name = "АйТиБорода",
                    Url = "https://youtube.com/itbeard"
                },
                new()
                {
                    Id = Guid.Parse("6BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                    Name = "Тёмный Лес",
                    Url = "https://youtube.com/thedarkless"
                }
            };

            builder.Entity<Brand>().HasData(brands.ToArray());
        }
    }
}