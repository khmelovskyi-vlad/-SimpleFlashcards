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
        public FlashcardsApiController(ApplicationDbContext context, IFlashcardCreator flashcardCreator, ISmallFlashcardBuilder smallFlashcardBuilder)
        {
            _context = context;
            _flashcardCreator = flashcardCreator;
            _smallFlashcardBuilder = smallFlashcardBuilder;
        }
        [HttpGet]
        [Route("{languageId}/{topicId?}")]
        public async Task<List<SmallFlashcard>> GetFlashcards(int languageId, Guid? topicId = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var flashcardQuery = _context.Flashcards.Where(f => f.UserId == user.Id);
            if (topicId != null)
            {
                flashcardQuery.Where(f => f.TopicId == topicId);
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
                var flashcard = await _context.Flashcards.FirstOrDefaultAsync(f => f.Id == flashcardModel.Id);
                flashcard.UpdateDate = DateTime.Now;
                if (flashcardModel.Topic.Id != null)
                {
                    flashcard.TopicId = flashcardModel.Topic.Id;
                }
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
