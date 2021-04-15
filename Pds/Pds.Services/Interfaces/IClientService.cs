using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models.Client;

namespace Pds.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetAsync(Guid clientId);
        Task<List<Client>> GetAllAsync();
        Task<Guid> CreateAsync(Client client);
        Task DeleteAsync(Guid ClientId);
        Task<List<Client>> GetClientsForListsAsync();
        Task<Guid> EditAsync(EditClientModel model);
    }
}