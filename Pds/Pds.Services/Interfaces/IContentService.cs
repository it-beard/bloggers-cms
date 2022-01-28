using Pds.Data.Entities;
using Pds.Services.Models.Content;

namespace Pds.Services.Interfaces;

public interface IContentService
{
    Task<List<Content>> GetAllAsync();
    Task<Content> GetAsync(Guid contentId);
    Task<Guid> CreateAsync(CreateContentModel model);
    Task<Guid> EditAsync(EditContentModel model);
    Task DeleteAsync(Guid clientId);
    Task ArchiveAsync(Guid contentId);
    Task UnarchiveAsync(Guid contentId);
    Task<List<Content>> GetContentsForListByBrandId(Guid brandId);
    Task<List<Content>> GetContentsForListByBrandIdWithSelectedValue(Guid brandId, Guid? selectedContentId);
}