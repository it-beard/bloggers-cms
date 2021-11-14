using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services;

public class GiftService : IGiftService
{
    private readonly IUnitOfWork unitOfWork;

    public GiftService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<Gift>> GetAllAsync()
    {
        return await unitOfWork.Gifts.GetAllAsync();
    }
}