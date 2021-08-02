using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Words
{
    public class Translation
    {
        public Guid WordId1 { get; set; }
        public Word Word1 { get; set; }
        public Guid WordId2 { get; set; }
        public Word Word2 { get; set; }
    }
}
