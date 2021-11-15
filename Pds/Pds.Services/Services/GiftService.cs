using Pds.Core.Enums;
using Pds.Core.Exceptions.Gift;
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
        return await unitOfWork.Gifts.GetAllFullAsync();
    }
    
    public async Task<Guid> CreateAsync(Gift gift)
    {
        if (gift == null)
        {
            throw new GiftCreateException("Запрос был пуст.");
        }

        if ((gift.Status == GiftStatus.Raffled || gift.Status == GiftStatus.Waiting) && 
                (string.IsNullOrWhiteSpace(gift.FirstName) 
                 || string.IsNullOrWhiteSpace(gift.LastName) 
                 || string.IsNullOrWhiteSpace(gift.PostalAddress)))
        {
            throw new GiftCreateException("Не указан адрес доставки или ФИО победителя");
        }

        gift.CreatedAt = DateTime.UtcNow;
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