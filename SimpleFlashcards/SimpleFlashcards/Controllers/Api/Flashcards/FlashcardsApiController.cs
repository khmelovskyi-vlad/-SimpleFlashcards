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
                await db.Flashcards.AddAsync(flashcard);
                await db.SaveChangesAsync();
            }
            return BadRequest();
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
