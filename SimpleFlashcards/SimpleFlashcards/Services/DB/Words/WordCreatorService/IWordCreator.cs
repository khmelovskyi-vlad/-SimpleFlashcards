using SimpleFlashcards.Models.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Words.WordCreatorService
{
    public interface IWordCreator
    {
        Task AddWords(List<WordModel> wordModels, Guid flashcardId);
    }
}
