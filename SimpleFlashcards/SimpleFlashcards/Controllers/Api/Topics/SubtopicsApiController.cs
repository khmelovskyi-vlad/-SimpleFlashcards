using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleFlashcards.Data;
using SimpleFlashcards.Models.Topics;
using SimpleFlashcards.Services.DB.Topics.TopicCreatorService;
using SimpleFlashcards.Services.DB.Topics.TopicEditorService;
using SimpleFlashcards.Services.Topics.Builders.TopicModelBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Controllers.Api.Topics
{
    [Route("api/subtopics")]
    [ApiController]
    public class SubtopicsApiController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }
        private ITopicCreator _topicCreator { get; set; }
        private ITopicEditor _topicEditor { get; set; }
        public SubtopicsApiController(ApplicationDbContext context, ITopicCreator topicCreator, ITopicEditor topicEditor)
        {
            _context = context;
            _topicCreator = topicCreator;
            _topicEditor = topicEditor;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTopic(SubtopicModel subtopicModel)
        {
            if (subtopicModel != null)
            {
                _topicCreator.AddSubtopic(subtopicModel);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(subtopicModel);
                }
                catch (Exception)
                {
                }
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditSubtopic(SubtopicModel subtopicModel)
        {
            if (subtopicModel != null)
            {
                var subtopic = await _context.Subtopics.FirstOrDefaultAsync(t => t.Topic.User.Email == User.Identity.Name && t.Id == subtopicModel.Id);
                _topicEditor.EditSubtopic(subtopic, subtopicModel);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(subtopicModel);
                }
                catch (Exception)
                {
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveSubtopic(Guid id)
        {
            var subtopic = await _context.Subtopics.FirstOrDefaultAsync(t => t.Topic.User.Email == User.Identity.Name && t.Id == id);
            if (subtopic != null)
            {
                _context.Subtopics.Remove(subtopic);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception)
                {
                }
            }
            return BadRequest();
        }
    }
}
