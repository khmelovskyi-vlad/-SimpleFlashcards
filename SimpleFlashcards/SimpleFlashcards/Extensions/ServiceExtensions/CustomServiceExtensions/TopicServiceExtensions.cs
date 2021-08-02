using Microsoft.Extensions.DependencyInjection;
using SimpleFlashcards.Services.Topics.Builders.TopicBuilderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions.ServiceExtensions.CustomServiceExtensions
{
    public static class TopicServiceExtensions
    {
        public static void AddTopicServices(this IServiceCollection services)
        {
            services.AddSingleton<ITopicBuilder, TopicBuilder>();
        }
    }
}
