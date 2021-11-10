using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class ResourceRepository : RepositoryBase<Resource>, IResourceRepository
{
    private readonly ApplicationDbContext context;
        
    public ResourceRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }

    // Can bee extended by any additional methods that do not present in RepositoryBase
}