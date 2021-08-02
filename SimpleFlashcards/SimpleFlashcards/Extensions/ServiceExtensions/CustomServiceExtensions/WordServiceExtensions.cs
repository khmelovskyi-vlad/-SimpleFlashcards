using Microsoft.Extensions.DependencyInjection;
using SimpleFlashcards.Services.Words.Builders.TranslationBuilderService;
using SimpleFlashcards.Services.Words.Builders.WordBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions.ServiceExtensions.CustomServiceExtensions
{
    public static class WordServiceExtensions
    {
        public static void AddWordServices(this IServiceCollection services)
        {
            services.AddSingleton<IWordBuilder, WordBuilder>();
            services.AddSingleton<ITranslationBuilder, TranslationBuilder>();
        }
    }
}
