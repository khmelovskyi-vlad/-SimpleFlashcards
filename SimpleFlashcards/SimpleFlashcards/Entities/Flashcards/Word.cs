using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<FlashcardWord> FlashcardWords { get; set; }
        public Guid? TParentId { get; set; }
        public Word TParent { get; set; }
        public List<Word> Translations { get; set; }
        public List<FileInfoFlashcardWord> Pronunciations { get; set; }


    }
}
