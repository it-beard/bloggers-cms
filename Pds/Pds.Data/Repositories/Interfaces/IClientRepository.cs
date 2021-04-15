using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<List<Client>> GetAllOrderByNameAsync();
        Task<List<Client>> GetAllWithBillsOrderByNameAsync();
        Task<Client> GetFullByIdAsync(Guid clientId);
        Task<bool> IsExistsByNameAsync(string clientName);
    }
}