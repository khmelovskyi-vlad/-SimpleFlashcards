using SimpleFlashcards.Entities.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class Flashcard
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public List<FlashcardTranslation> FlashcardTranslations { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<FileInfo> Images { get; set; }
    }
}
