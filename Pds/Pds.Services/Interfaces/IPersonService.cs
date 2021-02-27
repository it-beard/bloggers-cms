using System;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface IPersonService
    {
        Task<(Person[] people, int total)> GetAsync(int limit = 10, int offset = 0);
        Task<Guid> CreateAsync(Person newPerson);
    }
}