using SimpleFlashcards.Entities.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Topics
{
    public class FlashcardTopic
    {
        public Guid FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
