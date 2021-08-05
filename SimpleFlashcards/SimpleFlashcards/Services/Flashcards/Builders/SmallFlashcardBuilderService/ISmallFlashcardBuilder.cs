using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Flashcards.Builders.SmallFlashcardBuilderService
{
    public interface ISmallFlashcardBuilder
    {
        SmallFlashcard BuildSmallFlashcard(Word word, Flashcard flashcard);
        List<SmallFlashcard> BuildSmallFlashcards(List<Flashcard> flashcards, int languageId);
    }
}
