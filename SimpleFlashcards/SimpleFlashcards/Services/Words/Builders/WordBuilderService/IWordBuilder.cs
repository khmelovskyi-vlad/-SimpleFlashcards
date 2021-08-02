using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Words.Builders.WordBuilderService
{
    public interface IWordBuilder
    {
        Word BuildWord(WordModel wordModel);
        List<Word> BuildWords(List<WordModel> wordModels);
    }
}
