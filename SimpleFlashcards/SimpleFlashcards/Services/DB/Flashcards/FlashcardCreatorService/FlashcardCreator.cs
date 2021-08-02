using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Files;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using SimpleFlashcards.Models.Words;
using SimpleFlashcards.Services.DB.Topics.TopicCreatorService;
using SimpleFlashcards.Services.DB.Words.WordCreatorService;
using SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService;
using SimpleFlashcards.Services.Words.Builders.TranslationBuilderService;
using SimpleFlashcards.Services.Words.Builders.WordBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Flashcards.FlashcardCreatorService
{
    public class FlashcardCreator : IFlashcardCreator
    {
        private ApplicationDbContext _context { get; set; }
        private IFlashcardBuilder _flashcardBuilder { get; set; }
        private ITopicCreator _topicCreator { get; set; }
        private IWordCreator _wordCreator { get; set; }
        public FlashcardCreator(ApplicationDbContext context,
            IFlashcardBuilder flashcardBuilder,
            ITopicCreator topicCreator,
            IWordCreator wordCreator)
        {
            _context = context;
            _flashcardBuilder = flashcardBuilder;
            _topicCreator = topicCreator;
            _wordCreator = wordCreator;
        }
        public async Task<Flashcard> AddFlashcard(FlashcardModel flashcardModel, Guid userId)
        {
            flashcardModel.Words = flashcardModel.Words ?? new List<WordModel>();
            var topicId = _topicCreator.AddTopic(flashcardModel.Topic);
            var flashcard = _flashcardBuilder.BuildFlashcard(flashcardModel, userId, topicId);
            _context.Add(flashcard);
            await _wordCreator.AddWords(flashcardModel.Words, flashcard.Id);
            await AddImages(flashcardModel.Words);
            await AddPronunciations(flashcardModel.Words);
            return flashcard;
        }

        private async Task AddImages(List<WordModel> wordModels)
        {
            var imgIds = wordModels.Where(wm => !wm.IsCreated).SelectMany(wm => wm.ImageIds);
            var images = (await _context.FileInfoWordImages.Where(img => imgIds.Any(id => id == img.Id)).ToListAsync()) ?? new List<FileInfoWordImage>();
            foreach (var image in images)
            {
                var words = wordModels.Where(wm => wm.ImageIds != null && wm.ImageIds.Any(id => id == image.Id)) ?? new List<WordModel>();
                foreach (var word in words)
                {
                    image.WordId = word.Id;
                }
            }
        }
        private async Task AddPronunciations(List<WordModel> wordModels)
        {
            var imgIds = wordModels.Where(wm => !wm.IsCreated).SelectMany(wm => wm.ImageIds);
            var pronunciations = (await _context.FileInfoWordPronunciations.Where(img => imgIds.Any(id => id == img.Id)).ToListAsync()) ?? new List<FileInfoWordPronunciation>();
            foreach (var pronunciation in pronunciations)
            {
                var words = wordModels.Where(wm => wm.PronunciationIds != null && wm.ImageIds.Any(id => id == pronunciation.Id)) ?? new List<WordModel>();
                foreach (var word in words)
                {
                    pronunciation.WordId = word.Id;
                }
            }
        }
    }
}
