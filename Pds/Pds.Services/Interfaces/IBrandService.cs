using Pds.Data.Entities;
using Pds.Services.Models.Brand;

namespace Pds.Services.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetAllForListsAsync();

    Task<List<GetBrandModel>> GetAllAsync();
    
    Task<Guid> CreateAsync(Brand brand);
}