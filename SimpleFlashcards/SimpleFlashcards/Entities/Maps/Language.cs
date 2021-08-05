using SimpleFlashcards.Entities.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Maps
{
    public class Language
    {
        public Language()
        {

        }
        public Language(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rank { get; set; }
        public List<Word> Words { get; set; }
    }
}
