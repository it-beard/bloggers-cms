using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models;

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
            return await unitOfWork.Content.GetAllWithBillsAsync();
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
                Type = model.Type,
                ChannelId = model.ChannelId,
                SocialMediaType = model.SocialMediaType,
                Comment = model.Comment,
                ReleaseDateUtc = model.ReleaseDate,
                EndDateUtc = model.EndDateUtc,
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
                ChannelId = model.ChannelId,
                ClientId = model.ClientId
            };

            content.Bill = bill;
            content.BillId = bill.Id;
            var result = await unitOfWork.Content.InsertAsync(content);

            return result.Id;
        }
    }
}