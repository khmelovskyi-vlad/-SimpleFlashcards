using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class WordModel
    {
        public WordModel()
        {

        }
        public WordModel(Word flashcardWord)
        {
            if (flashcardWord != null)
            {
                Id = flashcardWord.Id;
                Value = flashcardWord.Value;
                Transcription = flashcardWord.Transcription;
                PartOfSpeech = flashcardWord.PartOfSpeech;
                if (flashcardWord.Country != null)
                {
                    CountryId = flashcardWord.CountryId;
                    Country = flashcardWord.Country.Name;
                }
                if (flashcardWord.Pronunciations != null)
                {
                    PronunciationIds = flashcardWord.Pronunciations.Select(el => el.Id).ToList();
                }
                //if (flashcardWord.FlashcardTranslations != null)
                //{
                //    FlashcardTranslations = flashcardWord.FlashcardTranslations.Select(el => new FlashcardWordModel(el.FlashcardWordId == flashcardWord.Id ? el.FlashcardWord : el.FlashcardWordAlso)).ToList();
                //}
            }
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public Guid? FlashcardId { get; set; }
        //public List<FlashcardWordModel> FlashcardTranslations { get; set; }
        public List<Guid> PronunciationIds { get; set; }
    }
}
