using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IContentRepository : IRepositoryBase<Content>
{
    Task<List<Content>> GetAllWithBillsAsync();
    Task<List<Content>> GetAllFullAsync();
    Task<Content> GetFullByIdAsync(Guid contentId);
    Task<Content> GetByIdWithBillAsync(Guid contentId);
    Task<Content> GetByIdWithBillWithCostsAsync(Guid contentId);
    Task<List<Content>> GetAllOrderByReleaseDateDescAsync();
    Task<Content> FullUpdateAsync(Content content);
    Task FullDeleteAsync(Content content);
    Task FullArchiveAsync(Content content);
}