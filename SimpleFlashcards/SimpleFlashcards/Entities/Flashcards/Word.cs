using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Maps;
using SimpleFlashcards.Models.Flashcards;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Flashcards
{
    public class Word
    {
        public Word()
        {

        }
        public Word(WordModel wordModel)
        {
            Id = Guid.NewGuid();
            Value = wordModel.Value;
            Transcription = wordModel.Transcription;
            PartOfSpeech = wordModel.PartOfSpeech;
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            CountryId = wordModel.CountryId;
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<FlashcardWord> FlashcardWords { get; set; }
        public Guid? TParentId { get; set; }
        public Word TParent { get; set; }
        public List<Word> Translations { get; set; }
        public List<FileInfoWordPronunciation> Pronunciations { get; set; }
        public List<FileInfoWordImage> Images { get; set; }
    }
}
