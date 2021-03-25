using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await unitOfWork.Persons.GetAllWithResourcesAsync();
        }

        public async Task<Guid> CreateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            
            person.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Persons.InsertAsync(person);

            return result.Id;
        }

        public async Task ArchiveAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person != null)
            {
                person.Status = PersonStatus.Archived;
                person.ArchivedAt = DateTime.UtcNow;
                await unitOfWork.Persons.UpdateAsync(person);
            }
        }

        public async Task UnarchiveAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person != null && person.Status == PersonStatus.Archived)
            {
                person.Status = PersonStatus.Active;
                person.UnarchivedAt = DateTime.UtcNow;
                await unitOfWork.Persons.UpdateAsync(person);
            }
        }

        public async Task DeleteAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person != null && person.Status == PersonStatus.Archived)
            {
                await unitOfWork.Persons.Delete(person);
            }
        }
    }
}