using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.DB.Topics.TopicEditorService
{
    public interface ITopicEditor
    {
        Topic EditTopic(Topic topic, TopicModel topicModel);
        Subtopic EditSubtopic(Subtopic subtopic, SubtopicModel subtopicModel);
        List<Subtopic> EditSubtopics(List<Subtopic> subtopics, List<SubtopicModel> subtopicModels);
    }
}
