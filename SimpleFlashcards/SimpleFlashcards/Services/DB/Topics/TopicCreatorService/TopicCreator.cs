using Microsoft.EntityFrameworkCore;
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
        public Topic AddTopic(TopicModel topicModel, Guid? userId = null)
        {
            Topic topic = new Topic();
            if (topicModel.IsCreated)
            {
                topic.Id = topicModel.Id;
            }
            else
            {
                topic = _topicBuilder.BuildTopic(topicModel, userId);
                _context.Topics.Add(topic);
            }
            if (topicModel.Subtopics != null)
            {
                AddSubtopics(topicModel.Subtopics, topic.Id);
            }
            return topic;
        }
        public List<Topic> AddTopics(List<TopicModel> topicModels, Guid? userId = null)
        {
            List<Topic> topics = new List<Topic>();
            foreach (var topicModel in topicModels)
            {
                Topic topic = AddTopic(topicModel, userId);
                topics.Add(topic);
            }
            return topics;
        }
        public Subtopic AddSubtopic(SubtopicModel subtopicModel)
        {
            var subtopic = _topicBuilder.BuildSubtopic(subtopicModel, subtopicModel.TopicId);
            _context.Subtopics.Add(subtopic);
            return subtopic;
        }
        public List<Subtopic> AddSubtopics(List<SubtopicModel> subtopicModels, Guid topicId)
        {
            var subtopics = _topicBuilder.BuildSubtopics(subtopicModels, topicId);
            _context.Subtopics.AddRange(subtopics);
            return subtopics;
        }
    }
}
