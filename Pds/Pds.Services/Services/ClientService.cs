using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Core.Exceptions.Client;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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

            client.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Clients.InsertAsync(client);

            return result.Id;
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var client = await unitOfWork.Clients.GetWithBillsByIdAsync(clientId);
            if (client.Bills != null && client.Bills.Count > 0)
            {
                throw new ClientDeleteException("Нельзя удалить клиента с привязанным контентом.");
            }

            if (client != null)
            {
                await unitOfWork.Clients.Delete(client);
            }
        }

        public async Task<List<Client>> GetClientsForListsAsync()
        {
            var clients = new List<Client> {new() {Id = Guid.Empty}}; //Add empty as a first element of list
            clients.AddRange(await unitOfWork.Clients.GetAllOrderByNameAsync());

            return clients;
        }
    }
}