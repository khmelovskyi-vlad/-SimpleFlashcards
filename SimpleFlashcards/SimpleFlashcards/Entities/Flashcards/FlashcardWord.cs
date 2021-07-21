using SimpleFlashcards.Entities.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class FlashcardWord
    {
        public Guid WordId { get; set; }
        public Word Word { get; set; }
        public Guid FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
    }
}
