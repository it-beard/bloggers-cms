using Microsoft.EntityFrameworkCore;
using Pds.Core.Constants;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    private readonly ApplicationDbContext context;

    public PersonRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<List<Person>> GetAllFullAsync()
    {
        return await context.Persons
            .Include(p=>p.Brands)
            .Include(p=>p.Resources)
            .Include(p=>p.Contents)
            .Where(p=>p.Brands.Any(b=>!b.IsArchived))
            .OrderBy(p =>p.LastName)
            .ThenByDescending(p=>p.Rate)
            .ToListAsync();
    }

    public async Task<Person> GetFullByIdAsync(Guid personId)
    {
        return await context.Persons
            .Include(p=>p.Brands)
            .Include(p=>p.Resources)
            .Include(p=>p.Contents)
            .FirstOrDefaultAsync(c => c.Id == personId);
    }

    public async Task<List<Person>> GetForListByBrandId(Guid brandId)
    {
        return await context.Persons
            .Where(p =>
                p.Brands.Select(b=>b.Id).Contains(brandId) &&
                p.Status != PersonStatus.Archived &&
                p.FirstName != PersonConstants.UnknownPersonMarker &&
                p.LastName != PersonConstants.UnknownPersonMarker)
            .OrderBy(p =>p.LastName)
            .ThenBy(p=>p.FirstName)
            .ToListAsync();
    }
}