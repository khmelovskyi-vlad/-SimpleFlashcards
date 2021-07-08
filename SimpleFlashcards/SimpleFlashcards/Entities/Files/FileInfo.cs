using SimpleFlashcards.Entities.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Files
{
    public class FileInfo
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string OriginalName { get; set; }
        public Guid? FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public Guid? FlashcardWordId { get; set; }
        public FlashcardWord FlashcardWord { get; set; }
    }
}
