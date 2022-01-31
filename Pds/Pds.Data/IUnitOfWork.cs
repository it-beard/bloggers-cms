using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data;

public interface IUnitOfWork : IDisposable
{
    IPersonRepository Persons { get; }
    IResourceRepository Resources { get; }
    IContentRepository Content { get; }
    IBrandRepository Brands { get; }
    IClientRepository Clients { get; }
    IBillRepository Bills { get; }
    ICostRepository Costs { get; }
    IGiftRepository Gifts { get; }
    ISettingRepository Settings { get; }
    IDashboardRepository Dashboard { get; }

    void Save();
    EntityEntry GetContextEntry(object obj);
}