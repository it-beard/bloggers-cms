﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var personTopics = topic.PersonTopics;
            topic.PersonTopics = null;
            var createdTopic = await unitOfWork.Topics.InsertAsync(topic);
            await RecreatePersonTopics(topic.Id, personTopics);
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
            var oldTopic = await unitOfWork.Topics.GetFirstWhereAsync(t => topic.Id == t.Id);
            if (oldTopic is null)
                throw new InvalidOperationException("Topic not found");
            HandleCreatedAtAndUpdatedAtChanges(topic, oldTopic);
            HandleStatusChanges(topic, oldTopic);
            var personTopics = topic.PersonTopics;
            await RecreatePersonTopics(topic.Id, personTopics);
            topic.PersonTopics = null;
            var updatedTopic = await unitOfWork.Topics.UpdateAsync(topic);
            return updatedTopic.Id;
        }

        private static void HandleCreatedAtAndUpdatedAtChanges(Topic topic, Topic oldTopic)
        {
            topic.UpdatedAt = DateTime.UtcNow;
            topic.CreatedAt = oldTopic.CreatedAt;
        }

        private void HandleStatusChanges(Topic topic, Topic oldTopic)
        {
            if (oldTopic.Status == topic.Status)
                return;
            if (oldTopic.Status == TopicStatus.Active
                && topic.Status == TopicStatus.Archived)
                topic.Archive();
            if (oldTopic.Status == TopicStatus.Archived
                && topic.Status == TopicStatus.Active)
                topic.Unarchive();
        }

        private async Task RecreatePersonTopics(Guid topicId, IEnumerable<PersonTopic> personTopics)
        {
            var newPersonTopics =  await RestorePersonTopics(topicId, personTopics);
            var oldPersonTopics = await unitOfWork.PersonTopics.FindAllByWhereAsync(pt => topicId == pt.TopicId);
            var removes = !oldPersonTopics.Any()
                ? new List<PersonTopic>(0)
                : oldPersonTopics.Where(oldPersonTopic => !newPersonTopics.Contains(oldPersonTopic))
                    .ToList();
            await unitOfWork.PersonTopics.DeleteRange(removes);
            var inserts = !oldPersonTopics.Any()
                ? newPersonTopics
                : newPersonTopics.Where(newPersonTopic => !oldPersonTopics.Contains(newPersonTopic))
                    .ToList();
            await unitOfWork.PersonTopics.InsertRangeAsync(inserts);
            
        }

        private async Task<IList<PersonTopic>> RestorePersonTopics(Guid topicId, IEnumerable<PersonTopic> personTopics)
        {
            var list = new List<PersonTopic>();
            foreach (var personTopic in personTopics)
            {
                var firstPerson = await unitOfWork.Persons
                    .GetFirstWhereAsync(person => personTopic.PersonId == person.Id);
                if (firstPerson is not null)
                    list.Add(new PersonTopic(topicId, firstPerson.Id));
            }

            return list;
        }
    }
}