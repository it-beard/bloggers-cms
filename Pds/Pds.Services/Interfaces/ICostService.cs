using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface ICostService
    {
        Task<List<Cost>> GetAllAsync();
        Task<Guid> CreateAsync(Cost cost);
        Task DeleteAsync(Guid costId);
    }
}