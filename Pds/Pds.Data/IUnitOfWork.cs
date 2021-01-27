using System;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }

        IResourceRepository Resource { get; }

        void Save();
    }
}