using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService
{
    public interface IFlashcardBuilder
    {
        Flashcard BuildFlashcard(FlashcardModel flashcardModel, Guid userId);
        List<FlashcardWord> BuildFlashcardWords(List<Word> words, List<Word> createdWords, Guid flashcardId);
    }
}
