using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models;

namespace Pds.Services.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetAllAsync();
        Task<Guid> CreateAsync(CreateContentModel model);
        Task DeleteAsync(Guid clientId);
    }
}