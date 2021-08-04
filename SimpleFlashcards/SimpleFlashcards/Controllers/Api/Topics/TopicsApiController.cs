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
    [Route("api/topics")]
    [ApiController]
    public class TopicsApiController : ControllerBase
    {
        private ApplicationDbContext _context { get; set; }
        private ITopicModelBuilder _topicModelBuilder { get; set; }
        private ITopicCreator _topicCreator { get; set; }
        private ITopicEditor _topicEditor { get; set; }
        public TopicsApiController(ApplicationDbContext context, ITopicModelBuilder topicModelBuilder, 
            ITopicCreator topicCreator, ITopicEditor topicEditor)
        {
            _context = context;
            _topicModelBuilder = topicModelBuilder;
            _topicCreator = topicCreator;
            _topicEditor = topicEditor;
        }
        [HttpGet]
        [Route("{part?}")]
        public async Task<IEnumerable<TopicModel>> GetTopics(string part = "")
        {
            var topics = await _context.Topics.Where(t => t.User.Email == User.Identity.Name && t.Value.Contains(part))
                .Take(20)
                .Include(t => t.Subtopics).ToListAsync();
            return topics.Select(t => _topicModelBuilder.BuildTopicModel(t));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTopic(TopicModel topicModel)
        {
            if (topicModel != null)
            {
                //
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                _topicCreator.AddTopic(topicModel, user.Id);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(topicModel);
                }
                catch (Exception)
                {
                }
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditTopic(TopicModel topicModel)
        {
            if (topicModel != null)
            {
                var topic = await _context.Topics.Include(t => t.Subtopics).FirstOrDefaultAsync(t => t.User.Email == User.Identity.Name && t.Id == topicModel.Id);
                _topicEditor.EditTopic(topic, topicModel);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(topicModel);
                }
                catch (Exception)
                {
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveTopic(Guid id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(t => t.User.Email == User.Identity.Name && t.Id == id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
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
