using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pds.Data.Repositories;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    private readonly Lazy<IPersonRepository> personRepository;
    private readonly Lazy<IResourceRepository> resourceRepository;
    private readonly Lazy<IContentRepository> contentRepository;
    private readonly Lazy<IBrandRepository> brandRepository;
    private readonly Lazy<IClientRepository> clientRepository;
    private readonly Lazy<IBillRepository> billRepository;
    private readonly Lazy<ICostRepository> costRepository;
    private readonly Lazy<IGiftRepository> giftRepository;
    private readonly Lazy<ISettingRepository> settingRepository;
    private readonly Lazy<IDashboardRepository> dashboardRepository;

    public UnitOfWork(
        ApplicationDbContext context,
        Lazy<IPersonRepository> personRepository,
        Lazy<IResourceRepository> resourceRepository,
        Lazy<IContentRepository> contentRepository,
        Lazy<IBrandRepository> brandRepository,
        Lazy<IClientRepository> clientRepository,
        Lazy<IBillRepository> billRepository,
        Lazy<ICostRepository> costRepository,
        Lazy<IGiftRepository> giftRepository,
        Lazy<ISettingRepository> settingRepository,
        Lazy<IDashboardRepository> dashboardRepository
    )
    {
        this.context = context;
        this.personRepository = personRepository;
        this.resourceRepository = resourceRepository;
        this.contentRepository = contentRepository;
        this.brandRepository = brandRepository;
        this.clientRepository = clientRepository;
        this.billRepository = billRepository;
        this.costRepository = costRepository;
        this.giftRepository = giftRepository;
        this.settingRepository = settingRepository;
        this.dashboardRepository = dashboardRepository;
    }

    public IPersonRepository Persons => personRepository.Value;
    public IResourceRepository Resources => resourceRepository.Value;
    public IContentRepository Content => contentRepository.Value;
    public IBrandRepository Brands => brandRepository.Value;
    public IClientRepository Clients => clientRepository.Value;
    public IBillRepository Bills => billRepository.Value;
    public ICostRepository Costs => costRepository.Value;
    public IGiftRepository Gifts => giftRepository.Value;
    public ISettingRepository Settings => settingRepository.Value;
    public IDashboardRepository Dashboard => dashboardRepository.Value;

    public EntityEntry GetContextEntry(object obj)
    {
        return context.Entry(obj);
    }
}