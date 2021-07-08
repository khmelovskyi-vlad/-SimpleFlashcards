using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Controllers.Api.Flashcards
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsApiController : ControllerBase
    {
        public async Task GetFlashcards()
        {

        }
    }
}
