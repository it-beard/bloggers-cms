using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork unitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(Topic topic)
        {
            topic.CreatedAt = DateTime.UtcNow;
            var createdTopic = await unitOfWork.Topics.InsertAsync(topic);
            return createdTopic.Id;
        }

        public Task<List<Topic>> GetAllAsync()
        {
            return unitOfWork.Topics.GetAllAsync();
        }

        public Task<Topic> FindById(Guid id)
        {
            return unitOfWork.Topics.GetFirstWhereAsync(t => t.Id == id);
        }

        public async Task<Guid> UpdateAsync(Topic topic)
        {
            topic.UpdatedAt = DateTime.UtcNow;
            var updatedTopic = await unitOfWork.Topics.UpdateAsync(topic);
            return updatedTopic.Id;
        }
    }
}