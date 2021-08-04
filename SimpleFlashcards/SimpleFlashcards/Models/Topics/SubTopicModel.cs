using SimpleFlashcards.Entities.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Topics
{
    public class SubtopicModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Topic { get; set; }
        public Guid TopicId { get; set; }
        public bool IsCreated { get; set; } = true;
    }
}
