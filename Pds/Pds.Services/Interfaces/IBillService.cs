using Pds.Data.Entities;
using Pds.Services.Models.Bill;
namespace Pds.Services.Interfaces;

public interface IBillService
{
    Task PayBillAsync(PayBillModel model);
    Task<Bill> GetAsync(Guid billId);
    Task<List<Bill>> GetAllPaidAsync();
    Task<Guid> CreateAsync(Bill bill);
    Task<Guid> EditAsync(EditBillModel model);
    Task ArchiveAsync(Guid billId);
    Task UnarchiveAsync(Guid billId);
    Task DeleteAsync(Guid billId);
}