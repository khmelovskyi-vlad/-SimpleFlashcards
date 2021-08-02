using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using SimpleFlashcards.Services.Topics.Builders.TopicBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.TopicCreatorService
{
    public class TopicCreator : ITopicCreator
    {
        private ApplicationDbContext _context { get; set; }
        private ITopicBuilder _topicBuilder { get; set; }
        public TopicCreator(ApplicationDbContext context, ITopicBuilder topicBuilder)
        {
            _context = context;
            _topicBuilder = topicBuilder;
        }
        public Guid AddTopic(TopicModel topicModel)
        {
            Topic topic = new Topic();
            if (topicModel.IsCreated)
            {
                topic.Id = topicModel.Id;
            }
            else
            {
                topic = _topicBuilder.BuildTopic(topicModel);
                _context.Topics.Add(topic);
            }
            if (topicModel.SubTopics != null)
            {
                var subTopics = _topicBuilder.BuildSubTopics(topicModel.SubTopics, topic.Id);
                _context.SubTopics.AddRange(subTopics);
            }
            return topic.Id;
        }
    }
}
