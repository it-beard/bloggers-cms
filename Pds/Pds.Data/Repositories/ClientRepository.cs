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
        
        public async Task<List<Client>> GetForListsAsync()
        {
            return await context.Clients
                .OrderBy(p =>p.Name)
                .ToListAsync();
        }
    }
}