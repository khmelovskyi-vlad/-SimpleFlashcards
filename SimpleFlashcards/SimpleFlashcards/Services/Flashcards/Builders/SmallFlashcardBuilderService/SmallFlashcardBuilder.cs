using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Flashcards.Builders.SmallFlashcardBuilderService
{
    public class SmallFlashcardBuilder : ISmallFlashcardBuilder
    {
        public SmallFlashcard BuildSmallFlashcard(Word word, Flashcard flashcard)
        {
            var smallFlashcards = new SmallFlashcard()
            {
                Id = flashcard.Id,
                UpdateDate = flashcard.UpdateDate,
                TopicIds = flashcard?.FlashcardTopics?.Select(ft => ft.TopicId)?.ToList() ?? new List<Guid>(),
                Transcription = word.Transcription,
                WordId = word.Id,
                Word = word.Value
            };
            return smallFlashcards;
        }
        public List<SmallFlashcard> BuildSmallFlashcards(List<Flashcard> flashcards, int languageId)
        {
            var smallFlashcards = new List<SmallFlashcard>();
            foreach (var flashcard in flashcards)
            {
                smallFlashcards.AddRange(flashcard.FlashcardWords
                                            .Where(fw => fw.IsMain)
                                            .Select(fw => fw.Word)
                                            .Where(w => w.LanguageId == languageId)
                                            .Select(w => BuildSmallFlashcard(w, flashcard)));
            }
            return smallFlashcards;
        }
    }
}
