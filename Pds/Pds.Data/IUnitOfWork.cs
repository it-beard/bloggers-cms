using System;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IResourceRepository Resources { get; }
        IContentRepository Content { get; }
        IBrandRepository Brands { get; }
        IClientRepository Clients { get; }
        IBillRepository Bills { get; }
        ITopicRepository Topics { get; }
        IPersonTopicRepository PersonTopics { get; }
        ICostRepository Costs { get; }

        void Save();
    }
}