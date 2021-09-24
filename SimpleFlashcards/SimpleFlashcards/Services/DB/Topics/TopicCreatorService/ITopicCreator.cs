using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.TopicCreatorService
{
    public interface ITopicCreator
    {
        Topic AddTopic(TopicModel topicModel, Guid? userId = null);
        List<Topic> AddTopics(List<TopicModel> topicModels, Guid? userId = null);
        Subtopic AddSubtopic(SubtopicModel subtopicModel);
        List<Subtopic> AddSubtopics(List<SubtopicModel> subtopicModels, Guid topicId);
    }
}
