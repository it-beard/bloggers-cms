using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IBillRepository : IRepositoryBase<Bill>
{
    Task<List<Bill>> GetAllPaidOrderByDateDescAsync();
    Task<Bill> GetFullByIdAsync(Guid billId);
}