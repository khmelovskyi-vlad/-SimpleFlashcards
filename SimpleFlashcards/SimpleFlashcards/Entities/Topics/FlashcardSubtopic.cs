using SimpleFlashcards.Entities.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Topics
{
    public class FlashcardSubtopic
    {
        public Guid FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public Guid SubtopicId { get; set; }
        public Subtopic Subtopic { get; set; }
    }
}
