using System;
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
           var createdTopic = await unitOfWork.Topics.InsertAsync(topic);
           return createdTopic.Id;
        }
    }
}