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
            if (flashcard.FlashcardWords != null)
            {
                Words = flashcard.FlashcardWords.Select(el => new WordModel(el.Word)).ToList();
            }
            if (flashcard.Topic != null)
            {
                Topic = new TopicModel(flashcard.Topic);
            }
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        //public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<WordModel> Words { get; set; }
        public TopicModel Topic { get; set; }
    }
}
