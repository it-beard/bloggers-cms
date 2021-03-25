using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetAllAsync();
        Task<Guid> CreateAsync(Content content);
    }
}