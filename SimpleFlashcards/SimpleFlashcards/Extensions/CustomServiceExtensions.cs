using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions
{
    public static class CustomServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddPermissions();
        }
    }
}
