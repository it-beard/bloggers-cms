using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models.Cost;

namespace Pds.Services.Interfaces
{
    public interface ICostService
    {
        Task<Cost> GetAsync(Guid costId);
        Task<List<Cost>> GetAllAsync();
        Task<Guid> CreateAsync(Cost cost);
        Task DeleteAsync(Guid costId);
        Task<Guid> EditAsync(EditCostModel model);
        Task ArchiveAsync(Guid costId);
        Task UnarchiveAsync(Guid costId);
    }
}