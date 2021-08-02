using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.TopicCreatorService
{
    public interface ITopicCreator
    {
        Guid AddTopic(TopicModel topicModel);
    }
}
