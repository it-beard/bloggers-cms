using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class SettingRepository : RepositoryBase<Setting>, ISettingRepository
{
    private readonly ApplicationDbContext context;
        
    public SettingRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}