using SimpleFlashcards.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.FlashcardTopicCreatorService
{
    public interface IFlashcardTopicCreator
    {
        List<FlashcardTopic> AddFlashcardTopics(IEnumerable<Guid> topicIds, Guid flashcardId);
    }
}
