using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IClientRepository : IRepositoryBase<Client>
{
    Task<List<Client>> GetAllActiveOrderByNameAsync();
    Task<List<Client>> GetAllWithBillsOrderByNameAsync();
    Task<Client> GetFullByIdAsync(Guid clientId);
    Task<bool> IsExistsByNameAsync(string clientName);
}