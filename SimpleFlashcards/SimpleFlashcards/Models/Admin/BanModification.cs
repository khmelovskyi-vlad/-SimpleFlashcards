using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Models.Admin
{
    public class BanModification
    {
        public Guid[] BanIds { get; set; }
        public Guid[] UnbanIds { get; set; }
    }
}
