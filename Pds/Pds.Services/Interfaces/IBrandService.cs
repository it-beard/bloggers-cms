using Pds.Data.Entities;

namespace Pds.Services.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetBrandsForListsAsync();
}