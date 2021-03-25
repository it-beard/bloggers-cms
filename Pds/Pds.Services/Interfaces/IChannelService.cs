using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface IChannelService
    {
        Task<List<Channel>> GetChannelsForListsAsync();
    }
}