using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Topics.Builders.TopicModelBuilderService
{
    public class TopicModelBuilder : ITopicModelBuilder
    {
        public TopicModel BuildTopicModel(Topic topic) 
        {
            var topicModel = new TopicModel()
            {
                Id = topic.Id,
                Value = topic.Value,
                UpdateDate = topic.UpdateDate
            };

            if (topic.Subtopics != null)
            {
                topicModel.Subtopics = topic.Subtopics.Select(el => BuildSubtopicModel(el)).ToList();
            }
            return topicModel;
        }
        public SubtopicModel BuildSubtopicModel(Subtopic subtopic)
        {
            var subtopicModel = new SubtopicModel()
            {
                Id = subtopic.Id,
                Value = subtopic.Value,
                UpdateDate = subtopic.UpdateDate,
                IsCreated = true
            };

            if (subtopic.Topic != null)
            {
                subtopicModel.Topic = subtopic.Topic.Value;
                subtopicModel.TopicId = subtopic.Topic.Id;
            }
            return subtopicModel;
        }
    }
}
