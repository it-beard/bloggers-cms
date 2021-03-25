using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IUnitOfWork unitOfWork;

        public ChannelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Channel>> GetChannelsForListsAsync()
        {
            return await unitOfWork.Channels.GetAllAsync();
        }
    }
}