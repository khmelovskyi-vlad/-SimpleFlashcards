using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService
{
    public class FlashcardBuilder : IFlashcardBuilder
    {
        public Flashcard BuildFlashcard(FlashcardModel flashcardModel, Guid userId)
        {
            var flashcard = new Flashcard();
            flashcard.Id = Guid.NewGuid();
            flashcard.CreationDate = DateTime.Now;
            flashcard.UpdateDate = DateTime.Now;
            flashcard.UserId = userId;
            return flashcard;
        }
        public List<FlashcardWord> BuildFlashcardWords(List<Word> words, List<Word> createdWords, Guid flashcardId)
        {
            var createdWordTranslations = createdWords.SelectMany(cw => cw.FlashcardWords).ToList();
            var flashcardWords = new List<FlashcardWord>();
            foreach (var word in words)
            {
                var flashcardWord = new FlashcardWord() { WordId = word.Id, FlashcardId = flashcardId };
                if (word.IsCreated && CheckFlashcardCreatedWords(flashcardWord, createdWordTranslations))
                {
                    continue;
                }
                flashcardWords.Add(flashcardWord);
            }
            return flashcardWords;
        }
        private bool CheckFlashcardCreatedWords(FlashcardWord flashcardWord, List<FlashcardWord> createdFlashcardWords)
        {
            return createdFlashcardWords.Any(cwt => (cwt.WordId == flashcardWord.WordId && cwt.FlashcardId == flashcardWord.FlashcardId));
        }
    }
}
