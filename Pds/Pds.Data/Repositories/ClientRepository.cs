using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly ApplicationDbContext context;
        
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public async Task<List<Client>> GetAllOrderByNameAsync()
        {
            return await context.Clients
                .OrderBy(p =>p.Name)
                .ToListAsync();
        }
        
        public async Task<List<Client>> GetAllWithBillsOrderByNameAsync()
        {
            return await context.Clients
                .Include(c=>c.Bills)
                .OrderBy(p =>p.Name)
                .ToListAsync();
        }
        
        public async Task<Client> GetWithBillsByIdAsync(Guid clientId)
        {
            return await context.Clients
                .Include(c => c.Bills)
                .FirstOrDefaultAsync(c => c.Id == clientId);
        }
        
        public async Task<bool> IsExistsByNameAsync(string clientName)
        {
            var client = await context.Clients
                .FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == clientName.ToLower().Trim());
            return client != null;
        }
    }
}