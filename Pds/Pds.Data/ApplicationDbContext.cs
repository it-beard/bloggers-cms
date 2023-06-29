using Microsoft.EntityFrameworkCore;
using Pds.Core;
using Pds.Core.Enums;
using Pds.Data.Entities;
namespace Pds.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Resource> Resources { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Gift> Gifts { get; set; }

    public DbSet<Setting> Settings { get; set; }

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

        modelBuilder.Entity<Setting>()
            .HasIndex(u => u.Key)
                .IsUnique();
    }

    private void SeedDate(ModelBuilder builder)
    {
        var brands = new List<Brand>
        {
            new()
            {
                Id = Guid.Parse("5AA23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Name = "АйТиБорода",
                Info = "https://youtube.com/itbeard",
                IsDefault = true
            },
            new()
            {
                Id = Guid.Parse("6BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Name = "Тёмный Лес",
                Info = "https://youtube.com/thedarkless"
            }
        };

        var settings = new List<Setting>
        {
            new()
            {
                Id = Guid.Parse("0BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.ExternalLink1Title,
                Value = "Link #1",
                Description = "Название первой custom-ссылки в меню навигации"
            },
            new()
            {
                Id = Guid.Parse("1BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.ExternalLink1Url,
                Value = "https://google.com",
                Description = "URL первой custom-ссылки в меню навигации"
            },
            new()
            {
                Id = Guid.Parse("2BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.ExternalLink2Title,
                Value = "Link #2",
                Description = "Название второй custom-ссылки в меню навигации"
            },
            new()
            {
                Id = Guid.Parse("3BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.ExternalLink2Url,
                Value = "https://youtube.com",
                Description = "URL второй custom-ссылки в меню навигации"
            },
            new()
            {
                Id = Guid.Parse("4BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.FilterContentReleaseDateFrom,
                Value = string.Empty,
                Description = "Значение по умолчанию для фильтра \"Контент -> Когда -> С\""
            },
            new()
            {
                Id = Guid.Parse("5BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.FilterBillsDateFrom,
                Value = string.Empty,
                Description = "Значение по умолчанию для фильтра \"Доходы -> Когда -> С\""
            },
            new()
            {
                Id = Guid.Parse("6BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.FilterCostsDateFrom,
                Value = string.Empty,
                Description = "Значение по умолчанию для фильтра \"Расходы -> Когда -> С\""
            },
            new()
            {
                Id = Guid.Parse("7BB23FA2-4B73-4A3F-C3D4-08D8D2705C5F"),
                Key = SettingsKeys.NotFilmedContentDefaultReleaseDate,
                Value = "12/14/2030",
                Description = "Значение по умолчанию даты выхода неснятого контента"
            }
        };

        builder.Entity<Brand>().HasData(brands.ToArray());
        builder.Entity<Setting>().HasData(settings.ToArray());
    }
}