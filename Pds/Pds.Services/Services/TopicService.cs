using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
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

        public async Task<Guid> ArchiveAsync(Guid topicId)
        {
            var topicFromDb = await unitOfWork.Topics.GetFirstWhereAsync(t => topicId == t.Id);
            topicFromDb.Archive();
            return await UpdateAsync(topicFromDb);
        }

        public async Task<Guid> UnarchiveAsync(Guid topicId)
        {
            var topicFromDb = await unitOfWork.Topics.GetFirstWhereAsync(t => topicId == t.Id);
            topicFromDb.Unarchive();
            return await UpdateAsync(topicFromDb);
        }

        public async Task<Guid> CreateAsync(Topic topic)
        {
            topic.CreatedAt = DateTime.UtcNow;
            topic.People = await AssignPeopleFromDb(topic.People);
            var createdTopic = await unitOfWork.Topics.InsertAsync(topic);
            return createdTopic.Id;
        }

        public Task<List<Topic>> GetAllAsync()
        {
            return unitOfWork.Topics.GetAllAsync();
        }

        public Task<Topic> FindById(Guid id)
        {
            return unitOfWork.Topics.GetFirstWithPeople(t => t.Id == id);
        }

        public async Task<Guid> UpdateAsync(Topic topic)
        {
            var oldTopic = await unitOfWork.Topics.GetFirstWhereAsync(t => topic.Id == t.Id);
            if (oldTopic is null)
                throw new InvalidOperationException("Topic not found");
            HandleCreatedAtAndUpdatedAtChanges(topic, oldTopic);
            HandleStatusChanges(topic, oldTopic);
            topic.People = await AssignPeopleFromDb(topic.People);
            var updatedTopic = await unitOfWork.Topics.UpdateAsync(topic);
            return updatedTopic.Id;
        }

        private static void HandleCreatedAtAndUpdatedAtChanges(Topic topic, Topic oldTopic)
        {
            topic.UpdatedAt = DateTime.UtcNow;
            topic.CreatedAt = oldTopic.CreatedAt;
        }

        private static void HandleStatusChanges(Topic topic, Topic oldTopic)
        {
            if (oldTopic.Status == topic.Status) return;
            switch (oldTopic.Status)
            {
                case TopicStatus.Active when topic.Status == TopicStatus.Archived:
                    topic.Archive();
                    break;
                case TopicStatus.Archived when topic.Status == TopicStatus.Active:
                    topic.Unarchive();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(oldTopic.Status),
                        oldTopic.Status,
                        "Cannot handle this status kind.");
            }
        }

        private async Task<ICollection<Person>> AssignPeopleFromDb(IEnumerable<Person> people)
        {
            var peopleFromDb = new List<Person>();

            foreach (var assignedPerson in people)
            {
                var personFromDb = await unitOfWork.Persons
                    .GetFirstWhereAsync(person => assignedPerson.Id == person.Id);
                if (personFromDb is not null)
                    peopleFromDb.Add(personFromDb);
            }

            return peopleFromDb;
        }
    }
}