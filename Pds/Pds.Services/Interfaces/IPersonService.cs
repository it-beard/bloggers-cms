using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Data.QueryCreators.Settings;

namespace Pds.Services.Interfaces
{
    public interface IPersonService
    {
        Task<(Person[] people, int total)> GetPagedAsync(SearchSettings<PersonsFieldName> searchSettings);
        Task<Guid> CreateAsync(Person newPerson);
        Task ArchiveAsync(Guid personId);
        Task UnarchiveAsync(Guid personId);
        Task DeleteAsync(Guid personId);
        Task<List<Person>> GetPersonsForListsAsync();
    }
}