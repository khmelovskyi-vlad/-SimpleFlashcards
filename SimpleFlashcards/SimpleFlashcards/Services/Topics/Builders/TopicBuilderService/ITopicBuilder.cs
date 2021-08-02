using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Topics.Builders.TopicBuilderService
{
    public interface ITopicBuilder
    {
        Topic BuildTopic(TopicModel topicModel);
        SubTopic BuildSubTopic(SubTopicModel subTopicModel, Guid topicId);
        List<SubTopic> BuildSubTopics(List<SubTopicModel> subTopicModels, Guid topicId);
    }
}
