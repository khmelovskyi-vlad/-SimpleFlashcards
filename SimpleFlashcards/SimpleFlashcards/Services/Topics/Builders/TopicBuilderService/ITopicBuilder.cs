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
        Topic BuildTopic(TopicModel topicModel, Guid? userId = null);
        Subtopic BuildSubtopic(SubtopicModel subtopicModel, Guid topicId);
        List<Subtopic> BuildSubtopics(List<SubtopicModel> subtopicModels, Guid topicId);
    }
}
