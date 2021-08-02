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
        public Topic BuildTopic(TopicModel topicModel) 
        {
            var topic = new Topic();
            topic.Id = Guid.NewGuid();
            topic.Value = topicModel.Value;
            topic.CreationDate = DateTime.Now;
            topic.UpdateDate = DateTime.Now;
            return topic;
        }
        public SubTopic BuildSubTopic(SubTopicModel subTopicModel, Guid topicId)
        {
            var subTopic = new SubTopic();
            subTopic.Id = Guid.NewGuid();
            subTopic.Value = subTopicModel.Value;
            subTopic.CreationDate = DateTime.Now;
            subTopic.UpdateDate = DateTime.Now;
            subTopic.TopicId = topicId;
            return subTopic;
        }
        public List<SubTopic> BuildSubTopics(List<SubTopicModel> subTopicModels, Guid topicId)
        {
            return subTopicModels.Where(subTopicModel => !subTopicModel.IsCreated).Select(subTopicModel => BuildSubTopic(subTopicModel, topicId)).ToList();
        }
    }
}
