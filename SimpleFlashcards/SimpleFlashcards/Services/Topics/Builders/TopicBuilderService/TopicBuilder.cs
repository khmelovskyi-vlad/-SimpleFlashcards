using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Topics.Builders.TopicBuilderService
{
    public class TopicBuilder : ITopicBuilder
    {
        public Topic BuildTopic(TopicModel topicModel, Guid? userId = null) 
        {
            var now = DateTime.Now;
            var topic = new Topic();
            topic.Id = Guid.NewGuid();
            topic.Value = topicModel.Value;
            topic.CreationDate = now;
            topic.UpdateDate = now;
            topic.UserId = userId;

            topicModel.Id = topic.Id;
            topicModel.UpdateDate = topic.UpdateDate;
            topicModel.CreationDate = topic.CreationDate;
            topicModel.IsCreated = true;
            return topic;
        }
        public Subtopic BuildSubtopic(SubtopicModel subtopicModel, Guid topicId)
        {
            var subtopic = new Subtopic();
            subtopic.Id = Guid.NewGuid();
            subtopic.Value = subtopicModel.Value;
            subtopic.CreationDate = DateTime.Now;
            subtopic.UpdateDate = DateTime.Now;
            subtopic.TopicId = topicId;

            subtopicModel.Id = subtopic.Id;
            subtopicModel.UpdateDate = subtopic.UpdateDate;
            subtopicModel.CreationDate = subtopic.CreationDate;
            subtopicModel.TopicId = subtopic.TopicId;
            subtopicModel.IsCreated = true;
            return subtopic;
        }
        public List<Subtopic> BuildSubtopics(List<SubtopicModel> subtopicModels, Guid topicId)
        {
            return subtopicModels.Where(subtopicModel => !subtopicModel.IsCreated).Select(subTopicModel => BuildSubtopic(subTopicModel, topicId)).ToList();
        }
    }
}
