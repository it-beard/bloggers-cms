using Pds.Core.Enums;
using Pds.Core.Exceptions.Gift;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Gift;

namespace Pds.Services.Services;

public class GiftService : IGiftService
{
    private readonly IUnitOfWork unitOfWork;

    public GiftService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Gift> GetAsync(Guid giftId)
    {
        return await unitOfWork.Gifts.GetFullByIdAsync(giftId);
    }

    public async Task<List<Gift>> GetAllAsync()
    {
        return await unitOfWork.Gifts.GetAllFullAsync();
    }
    
    public async Task<Guid> CreateAsync(Gift gift)
    {
        if (gift == null)
        {
            throw new GiftCreateException("Запрос был пуст.");
        }

        if (gift.Status == GiftStatus.Raffled && string.IsNullOrWhiteSpace(gift.Comment))
        {
            throw new GiftCreateException("Не указан адрес доставки или ФИО победителя");
        }
        
        if (gift.Status == GiftStatus.Waiting && 
            (string.IsNullOrWhiteSpace(gift.FirstName) 
             || string.IsNullOrWhiteSpace(gift.LastName) 
             || string.IsNullOrWhiteSpace(gift.PostalAddress)))
        {
            throw new GiftCreateException("Не указан адрес доставки или ФИО победителя");
        }

        gift.CreatedAt = DateTime.UtcNow;
        gift.FirstName = gift.FirstName.Trim();
        gift.LastName = gift.LastName.Trim();
        gift.ThirdName = gift.ThirdName.Trim();
        gift.Title = gift.Title.Trim();
        
        switch (gift.Status)
        {
            case GiftStatus.Raffled:
                gift.RaffledAt = DateTime.UtcNow;
                break;
            case GiftStatus.Completed:
                gift.CompletedAt = DateTime.UtcNow;
                break;
        }

        if (gift.ContentId == Guid.Empty)
        {
            gift.ContentId = null;
        }

        var result = await unitOfWork.Gifts.InsertAsync(gift);

        return result.Id;
    }
    
    public async Task<Guid> EditAsync(EditGiftModel model)
    {
        if (model == null)
        {
            throw new GiftEditException($"Модель запроса пуста.");
        }

        if (model.Status == GiftStatus.Raffled && string.IsNullOrWhiteSpace(model.Comment))
        {
            throw new GiftEditException("Не указан адрес доставки или ФИО победителя");
        }
        
        if (model.Status == GiftStatus.Waiting && 
            (string.IsNullOrWhiteSpace(model.FirstName) 
             || string.IsNullOrWhiteSpace(model.LastName) 
             || string.IsNullOrWhiteSpace(model.PostalAddress)))
        {
            throw new GiftEditException("Не указан адрес доставки или ФИО победителя");
        }

        var gift = await unitOfWork.Gifts.GetFullByIdAsync(model.Id);
            
        if (gift == null)
        {
            throw new GiftEditException($"Подарок с id {model.Id} не найден.");
        }

        if (gift.Status == GiftStatus.Completed)
        {
            throw new GiftEditException($"Нельзя редактировать отправленный подарок.");
        }

        gift.UpdatedAt = DateTime.UtcNow;
        gift.PreviousStatus = gift.Status;
        switch (model.Status)
        {
            case GiftStatus.Raffled:
                gift.RaffledAt = DateTime.UtcNow;
                break;
            case GiftStatus.Completed:
                gift.CompletedAt = DateTime.UtcNow;
                break;
        }
        gift.Title = model.Title;
        gift.Type = model.Type;
        gift.Status = model.Status;
        gift.Comment = model.Comment;
        gift.FirstName = model.FirstName;
        gift.LastName = model.LastName;
        gift.ThirdName = model.ThirdName;
        gift.PostalAddress = model.PostalAddress;
        gift.BrandId = model.BrandId;
        gift.ContentId = model.ContentId != null && model.ContentId.Value == Guid.Empty ? null : model.ContentId;

        var result = await unitOfWork.Gifts.UpdateAsync(gift);

        return result.Id;
    }
    
    public async Task CompleteAsync(Guid giftId)
    {
        var gift = await unitOfWork.Gifts.GetFirstWhereAsync(p => p.Id == giftId);
        if (gift != null)
        {
            gift.PreviousStatus = gift.Status;
            gift.Status = GiftStatus.Completed;
            gift.CompletedAt = DateTime.UtcNow;
            gift.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Gifts.UpdateAsync(gift);
        }
    }

    public async Task UncompleteAsync(Guid giftId)
    {
        var gift = await unitOfWork.Gifts.GetFirstWhereAsync(p => p.Id == giftId);
        if (gift != null)
        {
            gift.Status = gift.PreviousStatus ?? GiftStatus.New;
            gift.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.Gifts.UpdateAsync(gift);
        }
    }
    
    public async Task DeleteAsync(Guid giftId)
    {
        var gift = await unitOfWork.Gifts.GetFirstWhereAsync(p => p.Id == giftId);
            
        if (gift == null)
        {
            throw new GiftDeleteException($"Подарок с id {giftId} не найден.");
        }
            
        if (gift.Status == GiftStatus.Completed)
        {
            throw new GiftDeleteException($"Нельзя удалить отправленный подарок.");
        }

        await unitOfWork.Gifts.Delete(gift);
    }
}