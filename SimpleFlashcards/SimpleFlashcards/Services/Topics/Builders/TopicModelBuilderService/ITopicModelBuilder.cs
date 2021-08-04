using SimpleFlashcards.Entities.Topics;
using SimpleFlashcards.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Topics.Builders.TopicModelBuilderService
{
    public interface ITopicModelBuilder
    {
        TopicModel BuildTopicModel(Topic topic);
        SubtopicModel BuildSubtopicModel(Subtopic subtopic);
    }
}
