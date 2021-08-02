using Microsoft.Extensions.DependencyInjection;
using SimpleFlashcards.Services.Flashcards.Builders.FlashcardBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions.ServiceExtensions.CustomServiceExtensions
{
    public static class FlashcardServiceExtensions
    {
        public static void AddFlashcardServices(this IServiceCollection services)
        {
            services.AddSingleton<IFlashcardBuilder, FlashcardBuilder>();
        }
    }
}
