using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models.Bill;

namespace Pds.Services.Interfaces
{
    public interface ICostService
    {
        Task<List<Cost>> GetAllAsync();
    }
}