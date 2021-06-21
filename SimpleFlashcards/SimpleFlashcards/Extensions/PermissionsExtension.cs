using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards.Extensions
{
    public static class PermissionsExtension
    {
        public static void AddPermissions(this IServiceCollection services)
        {
            var permission = "permission";
            services.AddAuthorization(opts => {
                opts.AddPolicy("manageAllRoles", policy => {
                    policy.RequireClaim(permission, "manageAllRoles");
                });
            });
            services.AddAuthorization(opts => {
                opts.AddPolicy("manageManagers", policy => {
                    policy.RequireClaim(permission, "manageManagers");
                });
            });
            services.AddAuthorization(opts => {
                opts.AddPolicy("manageUsers", policy => {
                    policy.RequireClaim(permission, "manageUsers");
                });
            });
            services.AddAuthorization(opts => {
                opts.AddPolicy("banUser", policy => {
                    policy.RequireClaim(permission, "banUser");
                });
            });
            services.AddAuthorization(opts => {
                opts.AddPolicy("banIp", policy => {
                    policy.RequireClaim(permission, "banIp");
                });
            });
        }
    }
}
