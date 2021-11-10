using Pds.Data.Entities;
using Pds.Services.Models.Person;

namespace Pds.Services.Interfaces;

public interface IPersonService
{
    Task<Person> GetAsync(Guid personId);

    Task<List<Person>> GetAllAsync();

    Task<Guid> CreateAsync(Person person);

    Task<Guid> EditAsync(EditPersonModel model);

    Task ArchiveAsync(Guid personId);

    Task UnarchiveAsync(Guid personId);

    Task DeleteAsync(Guid personId);

    Task<List<Person>> GetPersonsForListsAsync();
}