using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Maps;
using SimpleFlashcards.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Words

{
    public class WordModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Transcription { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public int? LanguageId { get; set; }
        public LanguageModel Language { get; set; }
        public Guid? FlashcardId { get; set; }
        public List<Guid> ImageIds { get; set; }
        public List<Guid> PronunciationIds { get; set; }
        public bool IsMain { get; set; }
        public bool IsCreated { get; set; }
    }
}
