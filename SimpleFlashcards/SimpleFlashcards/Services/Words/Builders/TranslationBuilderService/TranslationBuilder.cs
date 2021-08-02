using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Words.Builders.TranslationBuilderService
{
    public class TranslationBuilder : ITranslationBuilder
    {
        public List<Translation> BuildTranslations(List<Word> newWords, List<Word> createdWords)
        {
            var translations = new List<Translation>();
            var newWordsGroup = newWords.GroupBy(wm => wm.CountryId).ToList();
            for (int i = 0; i < newWordsGroup.Count - 1; i++)
            {
                translations.AddRange(GetTranslations(newWordsGroup[i], newWordsGroup[i + 1], createdWords));
            }
            return translations;
        }
        private List<Translation> GetTranslations(IGrouping<Guid, Word> words1, IGrouping<Guid, Word> words2, List<Word> createdWords)
        {
            var createdWordTranslations = createdWords.SelectMany(cw => cw.Translations1).Union(createdWords.SelectMany(cw => cw.Translations2)).ToList();
            var translations = new List<Translation>();
            foreach (var word1 in words1)
            {
                foreach (var word2 in words2)
                {
                    var translation = new Translation() { WordId1 = word1.Id, WordId2 = word2.Id };
                    if (word1.IsCreated && word2.IsCreated && CheckTranslationCreatedWords(translation, createdWordTranslations))
                    {
                        continue;
                    }
                    translations.Add(translation);
                }
            }
            return translations;
        }
        private bool CheckTranslationCreatedWords(Translation translation, List<Translation> createdWordTranslations)
        {
            return createdWordTranslations.Any(cwt => (cwt.WordId1 == translation.WordId1 && cwt.WordId2 == translation.WordId2)
             || (cwt.WordId1 == translation.WordId2 && cwt.WordId2 == translation.WordId1));
        }
    }
}
