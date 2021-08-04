using SimpleFlashcards.Data;
using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using SimpleFlashcards.Services.DB.Topics.TopicCreatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.TopicEditorService
{
    public class TopicEditor : ITopicEditor
    {
        private ApplicationDbContext _context { get; set; }
        private ITopicCreator _topicCreator { get; set; }
        public TopicEditor(ApplicationDbContext context, ITopicCreator topicCreator)
        {
            _context = context;
            _topicCreator = topicCreator;
        }

        public Topic EditTopic(Topic topic, TopicModel topicModel)
        {
            topic.Value = topicModel.Value;
            topic.UpdateDate = DateTime.Now;
            topicModel.UpdateDate = DateTime.Now;
            if (topicModel.Subtopics != null && topicModel.Subtopics.Count > 0)
            {
                var newSubtopicModels = topicModel.Subtopics;
                if (topic.Subtopics != null)
                {
                    newSubtopicModels = topicModel.Subtopics.Where(sm => !topic.Subtopics.Any(s => s.Id == sm.Id)).ToList();
                    var editSubtopics = topic.Subtopics.Where(s => topicModel.Subtopics.Any(sm => (sm.Id == s.Id && sm.Value != s.Value))).ToList();
                    EditSubtopics(editSubtopics, topicModel.Subtopics);
                    var removingSubtopics = topic.Subtopics.Where(s => !topicModel.Subtopics.Any(sm => sm.Id == s.Id)).ToList();
                    _context.RemoveRange(removingSubtopics);
                }
                _topicCreator.AddSubtopics(newSubtopicModels, topic.Id);
            }
            return topic;
        }
        public Subtopic EditSubtopic(Subtopic subtopic, SubtopicModel subtopicModel)
        {
            subtopic.Value = subtopicModel.Value;
            subtopic.UpdateDate = DateTime.Now;

            subtopicModel.UpdateDate = subtopic.UpdateDate;
            return subtopic;
        }
        public List<Subtopic> EditSubtopics(List<Subtopic> subtopics, List<SubtopicModel> subtopicModels)
        {
            foreach (var subtopic in subtopics)
            {
                var subtopicModel = subtopicModels.FirstOrDefault(sm => sm.Id == subtopic.Id);
                if (subtopicModel != null)
                {
                    EditSubtopic(subtopic, subtopicModel);
                }
            }
            return subtopics;
        }
    }
}
