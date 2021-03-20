using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person[]> GetAllWithResourcesAsync(SearchSettings<PersonsFieldName> searchSettings);
    }
}