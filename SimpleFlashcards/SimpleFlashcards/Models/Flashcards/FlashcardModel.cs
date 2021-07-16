using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class FlashcardModel
    {
        public FlashcardModel()
        {

        }
        public FlashcardModel(Flashcard flashcard)
        {
            Id = flashcard.Id;
            Value = flashcard.Value;
            UpdateDate = flashcard.UpdateDate;
            if (flashcard.FlashcardTranslations != null)
            {
                FlashcardTranslations = flashcard.FlashcardTranslations.Select(el => new FlashcardTranslationModel(el)).ToList();
            }
            if (flashcard.Images != null)
            {
                ImageIds = flashcard.Images.Select(el => el.Id).ToList();
            }
            if (flashcard.Topic != null)
            {
                Topic = new TopicModel(flashcard.Topic);
            }
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<FlashcardTranslationModel> FlashcardTranslations { get; set; }
        public List<Guid> ImageIds { get; set; }
        public TopicModel Topic { get; set; }
    }
}
