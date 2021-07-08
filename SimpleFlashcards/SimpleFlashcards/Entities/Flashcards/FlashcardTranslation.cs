using SimpleFlashcards.Entities.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class FlashcardTranslation
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public Guid FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public List<FlashcardWord> FlashcardWords { get; set; }
    }
}
