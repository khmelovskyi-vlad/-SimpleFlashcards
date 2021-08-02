using SimpleFlashcards.Entities.Words;
using SimpleFlashcards.Models.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Services.Words.Builders.WordBuilderService
{
    public class WordBuilder : IWordBuilder
    {
        public Word BuildWord(WordModel wordModel)
        {
            var word = new Word();
            if (!wordModel.IsCreated)
            {
                word.Id = Guid.NewGuid();
            }
            word.Value = wordModel.Value;
            word.Transcription = wordModel.Transcription;
            word.PartOfSpeech = wordModel.PartOfSpeech;
            word.CreationDate = DateTime.Now;
            word.UpdateDate = DateTime.Now;
            word.CountryId = wordModel.CountryId;
            word.IsMain = wordModel.IsMain;
            word.IsCreated = wordModel.IsCreated;
            return word;
        }
        public List<Word> BuildWords(List<WordModel> wordModels)
        {
            return wordModels.Select(wordModel => BuildWord(wordModel)).ToList();
        }
    }
}
