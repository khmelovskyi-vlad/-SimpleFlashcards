using Microsoft.Extensions.DependencyInjection;
using SimpleFlashcards.Services.DB.Flashcards.FlashcardCreatorService;
using SimpleFlashcards.Services.DB.Topics.FlashcardTopicCreatorService;
using SimpleFlashcards.Services.DB.Topics.FlashcardTopicEditorService;
using SimpleFlashcards.Services.DB.Topics.TopicCreatorService;
using SimpleFlashcards.Services.DB.Topics.TopicEditorService;
using SimpleFlashcards.Services.DB.Words.WordCreatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions.ServiceExtensions.CustomServiceExtensions
{
    public static class DBServiceExtensions
    {
        public static void AddDBServices(this IServiceCollection services)
        {
            services.AddScoped<IFlashcardCreator, FlashcardCreator>();

            services.AddScoped<ITopicCreator, TopicCreator>();
            services.AddScoped<ITopicEditor, TopicEditor>();
            services.AddScoped<IFlashcardTopicCreator, FlashcardTopicCreator>();
            services.AddScoped<IFlashcardTopicEditor, FlashcardTopicEditor>();

            services.AddScoped<IWordCreator, WordCreator>();
        }
    }
}
