using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IBrandRepository : IRepositoryBase<Brand>
{
    Task<List<Brand>> GetAllAsync();
    Task<int> GetPersonsCountAsync(Guid brandId);
    Task<int> GetGiftsCountAsync(Guid brandId);
    Task<int> GetContentsCountAsync(Guid brandId);
    Task<decimal> GetCostsSumAsync(Guid brandId);
    Task<decimal> GetBillsSumAsync(Guid brandId);
}