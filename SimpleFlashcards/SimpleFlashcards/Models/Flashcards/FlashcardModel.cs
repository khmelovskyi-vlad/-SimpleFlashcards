using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Topics;
using SimpleFlashcards.Models.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Flashcards
{
    public class FlashcardModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<WordModel> Words { get; set; }
        public Guid? TopicId { get; set; }
        public TopicModel Topic { get; set; }
    }
}
