using SimpleFlashcards.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Topics
{
    public class TopicModel
    {
        public TopicModel()
        {

        }
        public TopicModel(Topic topic)
        {
            Id = topic.Id;
            Value = topic.Value;
            UpdateDate = topic.UpdateDate;
            if (topic.SubTopics != null)
            {
                SubTopics = topic.SubTopics.Select(el => new SubTopicModel(el)).ToList();
            }
            IsCreated = true;
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<SubTopicModel> SubTopics { get; set; }
        public bool IsCreated { get; set; }
    }
}
