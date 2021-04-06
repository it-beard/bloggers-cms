using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Data.QueryCreators.Settings;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<Person[]> GetAllWithResourcesAsync(SearchSettings<PersonsFieldName> searchSettings);
        Task<List<Person>> GetForListsAsync();
    }
}