using Microsoft.EntityFrameworkCore;
using Pds.Core.Enums;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data.Repositories;

public class GiftRepository : RepositoryBase<Gift>, IGiftRepository
{
    private readonly ApplicationDbContext context;
        
    public GiftRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}