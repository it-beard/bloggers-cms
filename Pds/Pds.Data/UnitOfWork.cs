using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    private IPersonRepository personRepository;
    private IResourceRepository resourceRepository;
    private IContentRepository contentRepository;
    private IBrandRepository brandRepository;
    private IClientRepository clientRepository;
    private IBillRepository billRepository;
    private ICostRepository costRepository;
    private IGiftRepository giftRepository;
    private ISettingRepository settingRepository;

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
    public ICostRepository Costs => costRepository ??= new CostRepository(context);
    public IGiftRepository Gifts => giftRepository ??= new GiftRepository(context);
    public ISettingRepository Settings => settingRepository ??= new SettingRepository(context);

    public void Save()
    {
        context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public EntityEntry GetContextEntry(object obj)
    {
        return context.Entry(obj);
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