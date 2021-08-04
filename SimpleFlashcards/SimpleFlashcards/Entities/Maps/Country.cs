﻿using SimpleFlashcards.Entities.Flashcards;
using SimpleFlashcards.Entities.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Entities.Maps
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Word> Words { get; set; }
    }
}
