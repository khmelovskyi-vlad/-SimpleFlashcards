using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.FlashcardTopicEditorService
{
    public interface IFlashcardTopicEditor
    {
        List<FlashcardTopic> ChangeFlashcardTopics(List<FlashcardTopic> flashcardTopics, List<TopicModel> topicModel, Guid flashcardId);
    }
}
