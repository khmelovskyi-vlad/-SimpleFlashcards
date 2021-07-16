using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
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
    public class FlashcardTranslationsController : ControllerBase
    {
        private ApplicationDbContext db { get; set; }
        public FlashcardTranslationsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("{flashcardId}")]
        public async Task<List<FlashcardTranslationModel>> GetFlashcards(Guid flashcardId)
        {
            return (await db.FlashcardTranslations.Where(f => f.FlashcardId == flashcardId).ToListAsync()).Select(f => new FlashcardTranslationModel(f)).ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<FlashcardTranslationModel> GetFlashcardTranslation(Guid id)
        {
            return new FlashcardTranslationModel((await db.FlashcardTranslations.FirstOrDefaultAsync(f => f.Id == id)));
        }
    }
}
