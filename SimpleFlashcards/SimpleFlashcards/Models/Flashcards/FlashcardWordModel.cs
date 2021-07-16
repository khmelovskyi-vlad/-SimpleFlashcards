using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class FlashcardWordModel
    {
        public FlashcardWordModel()
        {

        }
        public FlashcardWordModel(FlashcardWord flashcardWord)
        {
            Id = flashcardWord.Id;
            Value = flashcardWord.Value;
            Transcription = flashcardWord.Transcription;
            PartOfSpeech = flashcardWord.PartOfSpeech;
            FlashcardTranslationId = flashcardWord.FlashcardTranslationId;
            PronunciationId = flashcardWord.PronunciationId;
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public Guid FlashcardTranslationId { get; set; }
        public Guid? PronunciationId { get; set; }
    }
}
