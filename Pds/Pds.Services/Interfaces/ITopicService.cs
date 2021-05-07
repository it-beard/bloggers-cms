using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Guid> CreateAsync(Topic topic);
        Task<List<Topic>> GetAllAsync();
        Task<Topic> FindByIdAsync(Guid id);
        Task<Guid> UpdateAsync(Topic topic);
        Task<Guid> ArchiveAsync(Guid topicId);
        Task<Guid> UnarchiveAsync(Guid topicId);
    }
}