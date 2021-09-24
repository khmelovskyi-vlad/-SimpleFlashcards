using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Flashcards;
using SimpleFlashcards.Models.Words;
using SimpleFlashcards.Services.DB.Flashcards.FlashcardCreatorService;
using SimpleFlashcards.Services.DB.Topics.FlashcardTopicEditorService;
using SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService;
using SimpleFlashcards.Services.Flashcards.Builders.SmallFlashcardBuilderService;
using SimpleFlashcards.Services.Words.Builders.TranslationBuilderService;
using SimpleFlashcards.Services.Words.Builders.WordBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Controllers.Api.Flashcards
{
    [Authorize]
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardsApiController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }
        private IFlashcardCreator _flashcardCreator { get; set; }
        private ISmallFlashcardBuilder _smallFlashcardBuilder { get; set; }
        private IFlashcardTopicEditor _flashcardTopicEditor { get; set; }
        public FlashcardsApiController(ApplicationDbContext context, IFlashcardCreator flashcardCreator, ISmallFlashcardBuilder smallFlashcardBuilder, IFlashcardTopicEditor flashcardTopicEditor)
        {
            _context = context;
            _flashcardCreator = flashcardCreator;
            _smallFlashcardBuilder = smallFlashcardBuilder;
            _flashcardTopicEditor = flashcardTopicEditor;
        }
        [HttpPost]
        [Route("{languageId}")]
        public async Task<List<SmallFlashcard>> GetFlashcards(int languageId, List<Guid> topics)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var flashcardQuery = _context.Flashcards.Where(f => f.UserId == user.Id);
            if (topics != null)
            {
                flashcardQuery.Where(f => f.FlashcardTopics.Any(ft => topics.Any(id => id == ft.TopicId)));
            }
            var flashcards = await flashcardQuery
                .Take(20)
                .Include(f => f.FlashcardWords)
                .ThenInclude(fw => fw.Word)
                .ToListAsync();
            if (flashcards != null)
            {
                return _smallFlashcardBuilder.BuildSmallFlashcards(flashcards, languageId);
            }
            return new List<SmallFlashcard>();
        }
        //[HttpGet]
        //[Route("{topicId}")]
        //public async Task<List<FlashcardModel>> GetFlashcards(Guid topicId)
        //{
        //    //return new List<FlashcardModel>();
        //    return (await _context.Flashcards.Where(f => f.TopicId == topicId)
        //        .Include(f => f.Topic)
        //        .ThenInclude(t => t.Subtopics)
        //        .Include(f => f.FlashcardWords)
        //        .ThenInclude(fw => fw.Word)
        //        .ThenInclude(w => w.Country)
        //        .Include(f => f.FlashcardWords)
        //        .ThenInclude(fw => fw.Word)
        //        .ThenInclude(w => w.Pronunciations)
        //        .Include(f => f.FlashcardWords)
        //        .ThenInclude(fw => fw.Word)
        //        .ThenInclude(w => w.Images)
        //        .ToListAsync()).Select(f => new FlashcardModel(f)).ToList();
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<FlashcardModel> GetFlashcard(Guid id)
        //{
        //    //return new FlashcardModel();
        //    return new FlashcardModel((await _context.Flashcards.FirstOrDefaultAsync(f => f.Id == id)));
        //}
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddFlashcard(FlashcardModel flashcardModel)
        {
            if (flashcardModel != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var flashcard = await _flashcardCreator.AddFlashcard(flashcardModel, user.Id);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditFlashcard(FlashcardModel flashcardModel)
        {
            if (flashcardModel != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                var flashcard = await _context.Flashcards.Include(f => f.FlashcardTopics).FirstOrDefaultAsync(f => f.Id == flashcardModel.Id);
                flashcard.UpdateDate = DateTime.Now;
                _flashcardTopicEditor.ChangeFlashcardTopics(flashcard.FlashcardTopics ?? new List<Entities.Topics.FlashcardTopic>(), flashcardModel.Topics ?? new List<Models.Topics.TopicModel>(), flashcard.Id);
                await _context.SaveChangesAsync();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveFlashcard(Guid id)
        {
            var flashcard = await _context.Flashcards.FirstOrDefaultAsync(f => f.Id == id);
            _context.Flashcards.Remove(flashcard);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
