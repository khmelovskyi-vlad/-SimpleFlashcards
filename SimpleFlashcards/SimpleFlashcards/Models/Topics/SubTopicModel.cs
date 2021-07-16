using SimpleFlashcards.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Topics
{
    public class SubTopicModel
    {
        public SubTopicModel()
        {

        }
        public SubTopicModel(SubTopic subTopic)
        {
            Id = subTopic.Id;
            Value = subTopic.Value;
            UpdateDate = subTopic.UpdateDate;
            Topic = subTopic.Topic?.Value;
            TopicId = subTopic.TopicId;
        }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Topic { get; set; }
        public Guid TopicId { get; set; }
    }
}
