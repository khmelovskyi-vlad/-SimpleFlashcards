using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions.ServiceExtensions.CustomServiceExtensions
{
    public static class MainCustomServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddPermissions();
            services.AddDBServices();
            services.AddFlashcardServices();
            services.AddWordServices();
            services.AddTopicServices();
        }
    }
}
