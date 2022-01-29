using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IPersonRepository : IRepositoryBase<Person>
{
    Task<List<Person>> GetAllFullAsync();
    Task<Person> GetFullByIdAsync(Guid personId);
    Task<List<Person>> GetForListByBrandId(Guid brandId);
}