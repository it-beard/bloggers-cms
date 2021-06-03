using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Services.Models.Bill;

namespace Pds.Services.Interfaces
{
    public interface IBillService
    {
        Task PayBillAsync(PayBillModel model);
        Task<List<Bill>> GetAllPaidAsync();
        Task<Guid> CreateAsync(Bill bill);
        Task ArchiveAsync(Guid billId);
        Task UnarchiveAsync(Guid billId);
        Task DeleteAsync(Guid billId);
    }
}