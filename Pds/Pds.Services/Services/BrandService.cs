using Pds.Core.Exceptions.Brand;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork unitOfWork;

    public BrandService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<Brand>> GetAllForListsAsync()
    {
        return await unitOfWork.Brands.GetAllAsync();
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await unitOfWork.Brands.GetAllFullAsync();
    }
    
    public async Task<Guid> CreateAsync(Brand brand)
    {
        if (brand == null)
        {
            throw new ArgumentNullException(nameof(brand));
        }

        if (await unitOfWork.Clients.IsExistsByNameAsync(brand.Name))
        {
            throw new BrandCreateException("Бренд с таким именем существует в системе.");
        }

        brand.CreatedAt = DateTime.UtcNow;
        brand.Name = brand.Name.Trim();
        var result = await unitOfWork.Brands.InsertAsync(brand);

        return result.Id;
    }
}