using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories
{
    public class ChannelRepository : RepositoryBase<Channel>, IChannelRepository
    {
        private readonly ApplicationDbContext context;
        
        public ChannelRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}