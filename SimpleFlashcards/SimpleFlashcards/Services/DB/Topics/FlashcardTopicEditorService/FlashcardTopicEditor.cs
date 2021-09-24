using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using SimpleFlashcards.Services.DB.Topics.FlashcardTopicCreatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.FlashcardTopicEditorService
{
    public class FlashcardTopicEditor : IFlashcardTopicEditor
    {
        private ApplicationDbContext _context { get; set; }
        private IFlashcardTopicCreator _flashcardTopicCreator { get; set; }
        public FlashcardTopicEditor(ApplicationDbContext context, IFlashcardTopicCreator flashcardTopicCreator)
        {
            _context = context;
            _flashcardTopicCreator = flashcardTopicCreator;
        }
        public List<FlashcardTopic> ChangeFlashcardTopics(List<FlashcardTopic> flashcardTopics, List<TopicModel> topicModel, Guid flashcardId)
        {
            var newFlashcardTopicIds = topicModel.Where(fm => !flashcardTopics.Any(ft => ft.TopicId == fm.Id)).Select(fm => fm.Id);
            var removeFlashcardTopics = flashcardTopics.Where(ft => topicModel.Any(fm => fm.Id == ft.TopicId));
            _flashcardTopicCreator.AddFlashcardTopics(newFlashcardTopicIds, flashcardId);
            _context.FlashcardTopics.RemoveRange(removeFlashcardTopics);
            return flashcardTopics;
        }
    }
}
