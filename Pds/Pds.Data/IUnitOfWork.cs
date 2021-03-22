using System;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IResourceRepository Resources { get; }
        IContentRepository Content { get; }
        IChannelRepository Channels { get; }
        IClientRepository Clients { get; }
        IOrderRepository Orders { get; }

        void Save();
    }
}