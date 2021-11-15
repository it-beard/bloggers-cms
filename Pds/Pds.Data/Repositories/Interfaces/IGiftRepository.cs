using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IGiftRepository : IRepositoryBase<Gift>
{
    Task<List<Gift>> GetAllFullAsync();

    Task<Gift> GetFullByIdAsync(Guid giftId);
}