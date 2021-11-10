using Pds.Core.Enums;
using Pds.Core.Exceptions.Content;
using Pds.Core.Exceptions.Cost;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Cost;

namespace Pds.Services.Services;

public class CostService : ICostService
{
    private readonly IUnitOfWork unitOfWork;

    public CostService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Cost> GetAsync(Guid costId)
    {
        return await unitOfWork.Costs.GetFullByIdAsync(costId);
    }

    public async Task<List<Cost>> GetAllAsync()
    {
        return await unitOfWork.Costs.GetAllOrderByDateDescAsync();
    }

    public async Task<Guid> CreateAsync(Cost cost)
    {
        if (cost == null)
        {
            throw new ArgumentNullException(nameof(cost));
        }

        cost.CreatedAt = DateTime.UtcNow;
        cost.Status = CostStatus.Active;
        var result = await unitOfWork.Costs.InsertAsync(cost);

        return result.Id;
    }

    public async Task<Guid> EditAsync(EditCostModel model)
    {
        if (model == null)
        {
            throw new CostEditException($"Модель запроса пуста.");
        }

        var cost = await unitOfWork.Costs.GetFullByIdAsync(model.Id);
            
        if (cost == null)
        {
            throw new CostEditException($"Расход с id {model.Id} не найден.");
        }

        if (cost.Status == CostStatus.Archived)
        {
            throw new ContentEditException($"Нельзя редактировать архивный расход.");
        }

        cost.UpdatedAt = DateTime.UtcNow;
        cost.Value = model.Value;
        cost.Comment = model.Comment;
        cost.PaidAt = model.PaidAt;
        cost.Comment = model.Comment;
        cost.Type = model.Type;
        cost.BrandId = model.BrandId;
        cost.ContentId = model.ContentId != null && model.ContentId.Value == Guid.Empty ? null : model.ContentId;;

        var result = await unitOfWork.Costs.UpdateAsync(cost);

        return result.Id;
    }

    public async Task ArchiveAsync(Guid costId)
    {
        var cost = await unitOfWork.Costs.GetFirstWhereAsync(p => p.Id == costId);
        if (cost != null)
        {
            cost.Status = CostStatus.Archived;
            cost.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Costs.UpdateAsync(cost);
        }
    }

    public async Task UnarchiveAsync(Guid costId)
    {
        var cost = await unitOfWork.Costs.GetFirstWhereAsync(p => p.Id == costId);
        if (cost is {Status: CostStatus.Archived})
        {
            cost.Status = CostStatus.Active;
            cost.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Costs.UpdateAsync(cost);
        }
    }

    public async Task DeleteAsync(Guid costId)
    {
        var cost = await unitOfWork.Costs.GetFirstWhereAsync(p => p.Id == costId);
            
        if (cost == null)
        {
            throw new CostDeleteException($"Расход с id {costId} не найден.");
        }
            
        if (cost.Status == CostStatus.Archived)
        {
            throw new CostDeleteException($"Нельзя удалить архивный расход.");
        }

        await unitOfWork.Costs.Delete(cost);
    }
}