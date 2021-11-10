using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface ICostRepository : IRepositoryBase<Cost>
{
    Task<List<Cost>> GetAllOrderByDateDescAsync();
    Task<Cost> GetFullByIdAsync(Guid costId);
}