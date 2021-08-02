using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Flashcards.FlashcardCreatorService
{
    public interface IFlashcardCreator
    {
        Task<Flashcard> AddFlashcard(FlashcardModel flashcardModel, Guid userId);
    }
}
