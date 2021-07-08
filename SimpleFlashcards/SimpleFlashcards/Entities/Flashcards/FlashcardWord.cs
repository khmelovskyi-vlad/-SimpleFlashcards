using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class FlashcardWord
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public Guid FlashcardTranslationId { get; set; }
        public FlashcardTranslation FlashcardTranslation { get; set; }
        public Guid? PronunciationId { get; set; }
        public FileInfo Pronunciation { get; set; }
    }
}
