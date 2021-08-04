using SimpleFlashcards.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Topics
{
    public class TopicModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<SubtopicModel> Subtopics { get; set; }
        public bool IsCreated { get; set; } = true;
    }
}
