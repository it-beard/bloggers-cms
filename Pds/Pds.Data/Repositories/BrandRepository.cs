using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    private readonly ApplicationDbContext context;
        
    public BrandRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}