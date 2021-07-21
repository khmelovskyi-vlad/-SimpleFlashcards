using SimpleFlashcards.Entities.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Maps
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Word> Words { get; set; }
    }
}
