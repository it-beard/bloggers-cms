using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Core.Exceptions.Person;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Data.QueryCreators.Settings;
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

        public async Task<(Person[] people, int total)> GetPagedAsync(SearchSettings<PersonsFieldName> searchSettings)
        {
            var result = await unitOfWork.Persons.GetAllWithResourcesAsync(searchSettings);
            var total = await unitOfWork.Persons.Count();

            return (result, total);
        }

        public async Task<Guid> CreateAsync(Person newPerson)
        {
            if (newPerson == null)
            {
                throw new ArgumentNullException(nameof(newPerson));
            }

            if (newPerson.Brands.Count == 0)
            {
                throw new PersonCreateException("Персону нельзя создать без бренда.");
            }
            
            // Restore brands from DB
            var brandsFromApi = newPerson.Brands;
            var brandsFromBd = new List<Brand>();
            foreach (var brandFromApi in brandsFromApi)
            {
                var brandFromDb = await unitOfWork.Brands.GetFirstWhereAsync(c => c.Id == brandFromApi.Id);
                if (brandFromDb != null)
                {
                    brandsFromBd.Add(brandFromDb);
                }
            }

            newPerson.Brands = brandsFromBd;
            newPerson.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Persons.InsertAsync(newPerson);

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

        public async Task<List<Person>> GetPersonsForListsAsync()
        {
            
            var persons = new List<Person> {new() {Id = Guid.Empty}};
            var personsFromDb = await unitOfWork.Persons.GetForListsAsync();
            persons.AddRange(personsFromDb);

            return persons;
        }
    }
}