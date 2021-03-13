using System;
using System.Threading.Tasks;
using Pds.Data.Entities;
using Pds.Data.Repositories;

namespace Pds.Services.Interfaces
{
    public interface IPersonService
    {
        Task<(Person[] people, int total)> GetAsync(SearchSettings searchSettings);
        Task<Guid> CreateAsync(Person newPerson);
    }
}