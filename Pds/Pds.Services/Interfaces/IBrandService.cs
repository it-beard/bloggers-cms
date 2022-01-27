using Pds.Data.Entities;

namespace Pds.Services.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetAllForListsAsync();

    Task<List<Brand>> GetAllAsync();
    
    Task<Guid> CreateAsync(Brand brand);
}