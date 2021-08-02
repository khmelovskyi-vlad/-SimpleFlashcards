using SimpleFlashcards.Entities.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Words.Builders.TranslationBuilderService
{
    public interface ITranslationBuilder
    {
        List<Translation> BuildTranslations(List<Word> newWords, List<Word> createdWords);
    }
}
