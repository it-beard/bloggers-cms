using Pds.Data.Entities;
using Pds.Services.Models.Brand;

namespace Pds.Services.Interfaces;

public interface IBrandService
{
    Task<Brand> GetAsync(Guid brandId);
    Task<List<Brand>> GetAllForListsAsync();
    Task<List<GetBrandModel>> GetAllAsync();
    Task<Guid> CreateAsync(Brand brand);
    Task<Guid> EditAsync(EditBrandModel model);
    Task DeleteAsync(Guid brandId);
    Task MakeDefaultAsync(Guid brandId);
}