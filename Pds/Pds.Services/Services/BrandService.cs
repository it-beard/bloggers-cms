using AutoMapper;
using Pds.Core.Exceptions.Brand;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Brand;

namespace Pds.Services.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }    
    
    public async Task<Brand> GetAsync(Guid brandId)
    {
        return await unitOfWork.Brands.GetFirstWhereAsync(b => b.Id == brandId);
    }

    public async Task<List<Brand>> GetAllForListsAsync()
    {
        return await unitOfWork.Brands.GetAllAsync();
    }

    public async Task<List<GetBrandModel>> GetAllAsync()
    {
        var brandsModels = new List<GetBrandModel>();
        var brands = await unitOfWork.Brands.GetAllAsync();
        foreach (var brand in brands)
        {
            var brandModel = mapper.Map<GetBrandModel>(brand);
            brandModel.PersonsCount = await unitOfWork.Brands.GetPersonsCountAsync(brand.Id);
            brandModel.ContentsCount = await unitOfWork.Brands.GetContentsCountAsync(brand.Id);
            brandModel.CostsSum = await unitOfWork.Brands.GetCostsSumAsync(brand.Id);
            brandModel.BillsSum = await unitOfWork.Brands.GetBillsSumAsync(brand.Id);
            brandModel.GiftsCount = await unitOfWork.Brands.GetGiftsCountAsync(brand.Id);

            if (brandModel.PersonsCount +
                brandModel.ContentsCount +
                brandModel.CostsSum +
                brandModel.BillsSum +
                brandModel.GiftsCount <= 0)
            {
                brandModel.IsDeletable = true;
            }
            
            brandsModels.Add(brandModel);
        }
        
        return brandsModels;
    }
    
    public async Task<Guid> CreateAsync(Brand brand)
    {
        if (brand == null)
        {
            throw new ArgumentNullException(nameof(brand));
        }

        if (await unitOfWork.Brands.IsExistsByNameAsync(brand.Name))
        {
            throw new BrandCreateException("Бренд с таким именем существует в системе.");
        }

        brand.CreatedAt = DateTime.UtcNow;
        brand.Name = brand.Name.Trim();
        var result = await unitOfWork.Brands.InsertAsync(brand);

        return result.Id;
    }
    
    public async Task<Guid> EditAsync(EditBrandModel model)
    {
        if (model == null)
        {
            throw new BrandEditException("Модель запроса пуста.");
        }

        var brand = await unitOfWork.Brands.GetFirstWhereAsync(b => b.Id == model.Id);

        if (brand == null)
        {
            throw new BrandEditException($"Бренд с id {model.Id} не найден.");
        }

        if (brand.Name != model.Name && await unitOfWork.Brands.IsExistsByNameAsync(model.Name))
        {
            throw new BrandEditException("Бренд с таким именем существует в системе.");
        }

        brand.UpdatedAt = DateTime.UtcNow;
        brand.Name = model.Name.Trim();
        brand.Info = model.Info;
        var result = await unitOfWork.Brands.UpdateAsync(brand);

        return result.Id;
    }
}