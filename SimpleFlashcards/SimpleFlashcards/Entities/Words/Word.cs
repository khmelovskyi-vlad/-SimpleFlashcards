using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Models.Flashcards;
using SimpleFlashcards.Models.Words;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Words
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<FlashcardWord> FlashcardWords { get; set; }
        public List<Translation> Translations1 { get; set; }
        public List<Translation> Translations2 { get; set; }
        public List<FileInfoWordPronunciation> Pronunciations { get; set; }
        public List<FileInfoWordImage> Images { get; set; }


        [NotMapped]
        public bool IsMain { get; set; }
        [NotMapped]
        public bool IsCreated { get; set; }
    }
}
