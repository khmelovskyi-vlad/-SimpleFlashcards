using SimpleFlashcards.Entities.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class SmallFlashcard
    {
        public Guid Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid WordId { get; set; }
        public string Word { get; set; }
        public string Transcription { get; set; }
        public List<Guid> TopicIds { get; set; }
    }
}
