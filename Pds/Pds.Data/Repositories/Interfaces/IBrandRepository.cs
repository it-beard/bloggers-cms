using Pds.Data.Entities;
using Pds.Services.Models.Brand;

namespace Pds.Data.Repositories.Interfaces;

public interface IBrandRepository : IRepositoryBase<Brand>
{
    Task<List<Brand>> GetAllAsync();
    Task<BrandAdditionalInfoModel> GetAdditionalInfoAsync(Guid brandId);
    Task<bool> IsExistsByNameAsync(string name);
}