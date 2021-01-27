using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        // Can bee extended by any additional methods that do not present in IRepositoryBase
    }
}