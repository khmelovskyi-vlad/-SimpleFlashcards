using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class FlashcardTranslationModel
    {
        public FlashcardTranslationModel()
        {

        }
        public FlashcardTranslationModel(FlashcardTranslation flashcardTranslation)
        {
            Id = flashcardTranslation.Id;
            Country = new CountryModel(flashcardTranslation.Country);
            FlashcardId = flashcardTranslation.FlashcardId;
            if (flashcardTranslation.FlashcardWords != null)
            {
                FlashcardWords = flashcardTranslation.FlashcardWords.Select(el => new FlashcardWordModel(el)).ToList();
            }
        }
        public Guid Id { get; set; }
        public CountryModel Country { get; set; }
        public Guid FlashcardId { get; set; }
        public List<FlashcardWordModel> FlashcardWords { get; set; }
    }
}
