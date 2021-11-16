using Pds.Data.Entities;
using Pds.Services.Models.Bill;
using Pds.Services.Models.Gift;

namespace Pds.Services.Interfaces;

public interface IGiftService
{
    Task<Gift> GetAsync(Guid giftId);

    Task<List<Gift>> GetAllAsync();

    Task<Guid> CreateAsync(Gift gift);

    Task<Guid> EditAsync(EditGiftModel model);

    Task CompleteAsync(Guid giftId);
    
    Task UncompleteAsync(Guid giftId);

    Task DeleteAsync(Guid giftId);
}