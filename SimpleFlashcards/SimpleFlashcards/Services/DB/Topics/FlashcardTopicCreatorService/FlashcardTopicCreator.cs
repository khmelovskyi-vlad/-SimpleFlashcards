using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.FlashcardTopicCreatorService
{
    public class FlashcardTopicCreator : IFlashcardTopicCreator
    {
        private ApplicationDbContext _context { get; set; }
        public FlashcardTopicCreator(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FlashcardTopic> AddFlashcardTopics(IEnumerable<Guid> topicIds, Guid flashcardId)
        {
            List<FlashcardTopic> flashcardTopics = new List<FlashcardTopic>();
            foreach (var topicId in topicIds)
            {
                FlashcardTopic flashcardTopic = new FlashcardTopic() { TopicId = topicId, FlashcardId = flashcardId };
                flashcardTopics.Add(flashcardTopic);
            }
            _context.FlashcardTopics.AddRange(flashcardTopics);
            return flashcardTopics;
        }
    }
}
