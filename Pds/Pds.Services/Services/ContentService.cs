using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

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
            return await unitOfWork.Content.GetAllWithOrdersAsync();
        }

        public async Task<Guid> CreateAsync(Content content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            
            content.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Content.InsertAsync(content);

            return result.Id;
        }
    }
}