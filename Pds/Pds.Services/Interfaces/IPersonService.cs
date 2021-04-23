using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> GetAsync(Guid personId);

        Task<List<Person>> GetAllAsync();

        Task<Guid> CreateAsync(Person person);

        Task ArchiveAsync(Guid personId);

        Task UnarchiveAsync(Guid personId);

        Task DeleteAsync(Guid personId);

        Task<List<Person>> GetPersonsForListsAsync();
    }
}