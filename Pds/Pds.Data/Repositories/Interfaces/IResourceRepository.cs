using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IResourceRepository : IRepositoryBase<Resource>
{
    // Can bee extended by any additional methods that do not present in IRepositoryBase
}