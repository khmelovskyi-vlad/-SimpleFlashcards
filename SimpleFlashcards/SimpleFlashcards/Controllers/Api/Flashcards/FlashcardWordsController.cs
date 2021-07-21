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
    public class FlashcardWordsController : ControllerBase
    {
        //private ApplicationDbContext db { get; set; }
        //public FlashcardWordsController(ApplicationDbContext db)
        //{
        //    this.db = db;
        //}
        //[HttpGet]
        //[Route("{flashcardTranslationId}")]
        //public async Task<List<FlashcardWordModel>> GetFlashcards(Guid flashcardId)
        //{
        //    //return new List<FlashcardModel>();
        //    return (await db.FlashcardWords.Where(f => f.FlashcardId == flashcardId).ToListAsync()).Select(f => new FlashcardWordModel(f)).ToList();
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<FlashcardWordModel> GetFlashcardTranslation(Guid id)
        //{
        //    //return new FlashcardModel();
        //    return new FlashcardWordModel((await db.FlashcardWords.FirstOrDefaultAsync(f => f.Id == id)));
        //}
    }
}
