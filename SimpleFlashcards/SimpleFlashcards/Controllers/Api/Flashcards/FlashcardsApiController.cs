using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Models.Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Controllers.Api.Flashcards
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsApiController : ControllerBase
    {
        private ApplicationDbContext db { get; set; }
        public FlashcardsApiController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("{topicId}")]
        public async Task<List<FlashcardModel>> GetFlashcards(Guid topicId)
        {
            //return new List<FlashcardModel>();
            return (await db.Flashcards.Where(f => f.TopicId == topicId).ToListAsync()).Select(f => new FlashcardModel(f)).ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<FlashcardModel> GetFlashcard(Guid id)
        {
            //return new FlashcardModel();
            return new FlashcardModel((await db.Flashcards.FirstOrDefaultAsync(f => f.Id == id)));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddFlashcard(FlashcardModel flashcardModel)
        {
            if (flashcardModel != null)
            {
                flashcardModel.Words = flashcardModel.Words ?? new List<WordModel>();
                var user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var flashcard = new Flashcard();
                flashcard.Id = Guid.NewGuid();
                flashcard.Value = flashcardModel.Value;
                flashcard.CreationDate = DateTime.Now;
                flashcard.UpdateDate = DateTime.Now;
                flashcard.UserId = user.Id;
                if (flashcardModel.Topic.Id != null)
                {
                    flashcard.TopicId = flashcardModel.Topic.Id;
                }
                AddWords(flashcardModel.Words, flashcard.Id);
                await AddImages(flashcardModel.Words);
                await AddPronunciations(flashcardModel.Words);
                await db.Flashcards.AddAsync(flashcard);
                await db.SaveChangesAsync();
            }
            return BadRequest();
        }
        private void AddWords(List<WordModel> wordModels, Guid flashcardId)
        {
            var mainWordModel = wordModels.FirstOrDefault(el => el.IsMain);
            var mainWordId = AddWord(mainWordModel, flashcardId, true);
            foreach (var wordModel in wordModels.Where(el => !el.IsMain))
            {
                AddWord(wordModel, flashcardId, false);
            }
        }
        private Guid AddWord(WordModel wordModel, Guid flashcardId, bool isMain)
        {
            if (!wordModel.IsCreated)
            {
                var word = new Word(wordModel);
                AddWord(word, flashcardId, isMain);
                wordModel.Id = word.Id;
            }
            AddFlashcardWords(wordModel.Id, flashcardId, isMain);
            return wordModel.Id;
        }
        //private Guid AddWord(WordModel wordModel, Guid flashcardId, bool isMain)
        //{
        //    if (wordModel.IsCreated)
        //    {
        //        AddFlashcardWords(wordModel.Id, flashcardId, isMain);
        //    }
        //    else
        //    {
        //        var word = new Word(wordModel);
        //        AddWord(word, flashcardId, isMain);
        //        wordModel.Id = word.Id;
        //        return word.Id;
        //    }
        //    return wordModel.Id;
        //}
        private void AddWord(Word word, Guid flashcardId, bool isMain)
        {
            db.Words.Add(word);
            AddFlashcardWords(word.Id, flashcardId, isMain);
        }
        private void AddFlashcardWords(Guid wordId, Guid flashcardId, bool isMain)
        {
            var flashcardWord = new FlashcardWord(flashcardId, wordId, isMain);
            db.FlashcardWords.Add(flashcardWord);
        }
        private async Task AddImages(List<WordModel> wordModels)
        {
            var imgIds = wordModels.SelectMany(wm => wm.ImageIds);
            var images = (await db.FileInfoWordImages.Where(img => imgIds.Any(id => id == img.Id) ).ToListAsync()) ?? new List<Entities.Files.FileInfoWordImage>();
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
            var imgIds = wordModels.SelectMany(wm => wm.ImageIds);
            var pronunciations = (await db.FileInfoWordPronunciations.Where(img => imgIds.Any(id => id == img.Id)).ToListAsync()) ?? new List<Entities.Files.FileInfoWordPronunciation>();
            foreach (var pronunciation in pronunciations)
            {
                var words = wordModels.Where(wm => wm.PronunciationIds != null && wm.ImageIds.Any(id => id == pronunciation.Id)) ?? new List<WordModel>();
                foreach (var word in words)
                {
                    pronunciation.WordId = word.Id;
                }
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditFlashcard(FlashcardModel flashcardModel)
        {
            if (flashcardModel != null)
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var flashcard = await db.Flashcards.FirstOrDefaultAsync(f => f.Id == flashcardModel.Id);
                flashcard.Value = flashcardModel.Value;
                flashcard.UpdateDate = DateTime.Now;
                if (flashcardModel.Topic.Id != null)
                {
                    flashcard.TopicId = flashcardModel.Topic.Id;
                }
                await db.SaveChangesAsync();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveFlashcard(Guid id)
        {
            var flashcard = await db.Flashcards.FirstOrDefaultAsync(f => f.Id == id);
            db.Flashcards.Remove(flashcard);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
