using Pds.Data.Entities;
using Pds.Services.Models.Client;

namespace Pds.Services.Interfaces;

public interface IClientService
{
    Task<Client> GetAsync(Guid clientId);

    Task<List<Client>> GetAllAsync();

    Task<Guid> CreateAsync(Client client);
    
    Task ArchiveAsync(Guid clientId);
    
    Task UnarchiveAsync(Guid clientId);

    Task DeleteAsync(Guid ClientId);

    Task<List<Client>> GetForListsAsync();
    
    Task<List<Client>> GetForListWithSelectedValueAsync(Guid? selectedClientId);

    Task<Guid> EditAsync(EditClientModel model);
}