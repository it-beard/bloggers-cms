using System.Collections.Generic;
using System.Threading.Tasks;
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
            return await unitOfWork.Persons.GetAllAsync();
        }
    }
}