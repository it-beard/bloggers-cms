using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models;
using Pds.Services.Models.Content;

namespace Pds.Services.Services
{
    public class ContentService : IContentService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Content>> GetAllAsync()
        {
            return await unitOfWork.Content.GetAllWithBillsWithClientsAsync();
        }

        public async Task<Content> GetAsync(Guid contentId)
        {
            return await unitOfWork.Content.GetByIdWithBillAsync(contentId);
        }

        public async Task<Guid> CreateAsync(CreateContentModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var content = new Content
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Title = model.Title,
                Status = ContentStatus.Active,
                Type = model.Type,
                BrandId = model.BrandId,
                SocialMediaType = model.SocialMediaType,
                Comment = model.Comment,
                ReleaseDateUtc = model.ReleaseDate.Date,
                EndDateUtc = model.EndDate?.Date,
                PersonId = model.PersonId
            };

            var bill = new Bill
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Comment = $"Created automatically  for content with id {content.Id}",
                Cost = model.BillCost,
                ContentId = content.Id,
                PrimaryContact = model.BillContact,
                PrimaryContactType = model.BillContactType,
                Status = model.BillCost == 0 ? BillStatus.Paid : BillStatus.Active,
                Type = BillType.Content,
                BrandId = model.BrandId,
                ClientId = model.ClientId
            };

            content.Bill = bill;
            content.BillId = bill.Id;
            var result = await unitOfWork.Content.InsertAsync(content);

            return result.Id;
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var content = await unitOfWork.Content.GetByIdWithBillAsync(clientId);
            if (content != null && 
                content.Status == ContentStatus.Active && 
                (content.Bill.Status == BillStatus.Active || content.Bill.Cost == 0))
            {
                await unitOfWork.Content.Delete(content);
                await unitOfWork.Bills.Delete(content.Bill);
            }
        }

        public async Task ArchiveAsync(Guid contentId)
        {
            var content = await unitOfWork.Content.GetByIdWithBillAsync(contentId);
            if (content != null && content.Status == ContentStatus.Active && content.Bill.Status == BillStatus.Paid)
            {
                content.Status = ContentStatus.Archived;
                content.UpdatedAt = DateTime.UtcNow;
                await unitOfWork.Content.UpdateAsync(content);
            }
        }
    }
}