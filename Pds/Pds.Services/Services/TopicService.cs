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
            Debug.Assert(ReferenceEquals(createdTopic, topic), "ReferenceEquals(createdTopic, topic)" );
            return createdTopic.Id;
        }

        public Task<List<Topic>> GetAllAsync()
        {
            return unitOfWork.Topics.GetAllAsync();
        }
    }
}