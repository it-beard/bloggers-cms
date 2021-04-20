using System;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private IBillRepository billRepository;
        private IBrandRepository brandRepository;
        private IClientRepository clientRepository;
        private IContentRepository contentRepository;
        private ICostRepository costRepository;

        private bool disposed;
        private IPersonRepository personRepository;
        private IResourceRepository resourceRepository;
        private ITopicRepository topicRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IPersonRepository Persons => personRepository ??= new PersonRepository(context);
        public IResourceRepository Resources => resourceRepository ??= new ResourceRepository(context);
        public IContentRepository Content => contentRepository ??= new ContentRepository(context);
        public IBrandRepository Brands => brandRepository ??= new BrandRepository(context);
        public IClientRepository Clients => clientRepository ??= new ClientRepository(context);
        public IBillRepository Bills => billRepository ??= new BillRepository(context);
        public ITopicRepository Topics => topicRepository ??= new TopicRepository(context);
        public ICostRepository Costs => costRepository ??= new CostRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }
    }
}