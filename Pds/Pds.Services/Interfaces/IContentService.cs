using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models.Content;

namespace Pds.Services.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetAllAsync();
        Task<Content> GetAsync(Guid contentId);
        Task<Guid> CreateAsync(CreateContentModel model);
        Task DeleteAsync(Guid clientId);
        Task ArchiveAsync(Guid contentId);
    }
}