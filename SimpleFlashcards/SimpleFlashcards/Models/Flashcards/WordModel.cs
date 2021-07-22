using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Maps;
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
        public WordModel(Word word)
        {
            if (word != null)
            {
                Id = word.Id;
                Value = word.Value;
                Transcription = word.Transcription;
                PartOfSpeech = word.PartOfSpeech;
                if (word.Country != null)
                {
                    CountryId = word.CountryId;
                    Country = new CountryModel(word.Country);
                }
                if (word.Pronunciations != null)
                {
                    PronunciationIds = word.Pronunciations.Select(el => el.Id).ToList();
                }
                if (word.Images != null)
                {
                    ImageIds = word.Images.Select(el => el.Id).ToList();
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
        public CountryModel Country { get; set; }
        public Guid? FlashcardId { get; set; }
        //public List<FlashcardWordModel> FlashcardTranslations { get; set; }
        public List<Guid> ImageIds { get; set; }
        public List<Guid> PronunciationIds { get; set; }
    }
}
