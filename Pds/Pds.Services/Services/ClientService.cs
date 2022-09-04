using Pds.Core.Enums;
using Pds.Core.Exceptions.Client;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Client;

namespace Pds.Services.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Client> GetAsync(Guid clientId)
    {
        return await unitOfWork.Clients.GetFullByIdAsync(clientId);
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await unitOfWork.Clients.GetAllWithBillsOrderByNameAsync();
    }

    public async Task<Guid> CreateAsync(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        if (await unitOfWork.Clients.IsExistsByNameAsync(client.Name))
        {
            throw new ClientCreateException("Клиент с таким именем существует в системе.");
        }

        client.CreatedAt = DateTime.UtcNow;
        client.Name = client.Name.Trim();
        client.Status = ClientStatus.Active;
        var result = await unitOfWork.Clients.InsertAsync(client);

        return result.Id;
    }

    public async Task<Guid> EditAsync(EditClientModel model)
    {
        if (model == null)
        {
            throw new ClientEditException("Модель запроса пуста.");
        }

        var client = await unitOfWork.Clients.GetFullByIdAsync(model.Id);

        if (client == null)
        {
            throw new ClientEditException($"Клиент с id {model.Id} не найден.");
        }
        
        if (client.Status == ClientStatus.Archived)
        {
            throw new ClientEditException($"Нельзя редактировать архивного клиента!");
        }

        if (client.Name != model.Name && await unitOfWork.Clients.IsExistsByNameAsync(model.Name))
        {
            throw new ClientEditException("Клиент с таким именем существует в системе.");
        }

        client.UpdatedAt = DateTime.UtcNow;
        client.Name = model.Name.Trim();
        client.Comment = model.Comment;
        client.Country = model.Country;
        var result = await unitOfWork.Clients.UpdateAsync(client);

        return result.Id;
    }
    
    public async Task ArchiveAsync(Guid clientId)
    {
        var client = await unitOfWork.Clients.GetFirstWhereAsync(p => p.Id == clientId);
        if (client != null)
        {
            client.Status = ClientStatus.Archived;
            client.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Clients.UpdateAsync(client);
        }
    }

    public async Task UnarchiveAsync(Guid clientId)
    {
        var client = await unitOfWork.Clients.GetFirstWhereAsync(p => p.Id == clientId);
        if (client is {Status: ClientStatus.Archived})
        {
            client.Status = ClientStatus.Active;
            client.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Clients.UpdateAsync(client);
        }
    }

    public async Task DeleteAsync(Guid clientId)
    { 
        var client = await unitOfWork.Clients.GetFullByIdAsync(clientId);
        if (client.Bills != null && client.Bills.Count > 0)
        {
            throw new ClientDeleteException("Нельзя удалить клиента с привязанным контентом.");
        }

        if (client != null)
        {
            await unitOfWork.Clients.Delete(client);
        }
    }

    public async Task<List<Client>> GetForListsAsync()
    {
        var clients = new List<Client> {new() {Id = Guid.Empty}}; //Add empty as a first element of list
        clients.AddRange(await unitOfWork.Clients.GetAllActiveOrderByNameAsync());

        return clients;
    }
    
    public async Task<List<Client>> GetForListWithSelectedValueAsync(Guid? selectedClientId)
    {
        var initialClients = await GetForListsAsync();
        if (selectedClientId == null || initialClients == null) return initialClients;  
        
        // Add selected client on top of the list if it possible
        var firstClient = await unitOfWork.Clients.GetFirstWhereAsync(c => c.Id == selectedClientId);
        initialClients.Remove(firstClient);
        initialClients = initialClients.Prepend(firstClient).ToList();

        return initialClients;
    }
}