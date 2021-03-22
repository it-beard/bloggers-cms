using System;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private IPersonRepository personRepository;
        private IResourceRepository resourceRepository;
        private IContentRepository contentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IPersonRepository Persons => personRepository ??= new PersonRepository(context);
        public IResourceRepository Resources => resourceRepository ??= new ResourceRepository(context);
        public IContentRepository Content => contentRepository ??= new ContentRepository(context);

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

        private void Dispose(bool disposing)
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