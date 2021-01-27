using System;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private IPersonRepository personRepository;
        private IResourceRepository resourceRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IPersonRepository Persons => personRepository ??= new PersonRepository(context);

        public IResourceRepository Resource => resourceRepository ??= new ResourceRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}