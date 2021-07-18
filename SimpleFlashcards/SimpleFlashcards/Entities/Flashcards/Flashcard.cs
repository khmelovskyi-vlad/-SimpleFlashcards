using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Identities.Base;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class Flashcard
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<FlashcardTranslation> FlashcardTranslations { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<FileInfoFlashcard> Images { get; set; }
        public Guid? TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
