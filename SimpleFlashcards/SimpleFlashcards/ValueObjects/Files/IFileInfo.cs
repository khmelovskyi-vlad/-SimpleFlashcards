using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.ValueObjects.Files
{
    public interface IFileInfo
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string OriginalName { get; set; }
        public FileType Type { get; set; }
    }
}
