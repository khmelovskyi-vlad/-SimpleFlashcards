using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Words;
using SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService;
using SimpleFlashcards.Services.Words.Builders.TranslationBuilderService;
using SimpleFlashcards.Services.Words.Builders.WordBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Words.WordCreatorService
{
    public class WordCreator : IWordCreator
    {
        private ApplicationDbContext _context { get; set; }
        private ITranslationBuilder _translationBuilder { get; set; }
        private IWordBuilder _wordBuilder { get; set; }
        private IFlashcardBuilder _flashcardBuilder { get; set; }
        public WordCreator(ApplicationDbContext context,
            ITranslationBuilder translationBuilder,
            IWordBuilder wordBuilder,
            IFlashcardBuilder flashcardBuilder)
        {
            _context = context;
            _translationBuilder = translationBuilder;
            _wordBuilder = wordBuilder;
            _flashcardBuilder = flashcardBuilder;
        }
        public async Task AddWords(List<WordModel> wordModels, Guid flashcardId)
        {
            var createdWords = await GetCreatedWords(wordModels);
            var words = _wordBuilder.BuildWords(wordModels);
            var translations = _translationBuilder.BuildTranslations(words, createdWords);
            var flashcardwords = _flashcardBuilder.BuildFlashcardWords(words, createdWords, flashcardId);
            AddWords(words, translations, flashcardwords);
        }

        private async Task<List<Word>> GetCreatedWords(List<WordModel> wordModels)
        {
            var createdWordsModel = wordModels.Where(wm => wm.IsCreated).Select(wm => wm.Id).ToList();
            if (createdWordsModel.Count > 0)
            {
                return await _context.Words.Where(w => createdWordsModel.Contains(w.Id))
                    .Include(w => w.FlashcardWords)
                    .Include(w => w.Translations1)
                    .Include(w => w.Translations2)
                    .ToListAsync();
            }
            return new List<Word>();
        }
        private void AddWords(IEnumerable<Word> words, List<Translation> translations, List<FlashcardWord> flashcardWords)
        {
            var noCreatedWords = words.Where(w => !w.IsCreated).ToList();
            _context.Words.AddRange(noCreatedWords);
            _context.Translations.AddRange(translations);
            _context.FlashcardWords.AddRange(flashcardWords);
        }
    }
}
