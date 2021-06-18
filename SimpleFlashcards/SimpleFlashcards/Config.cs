using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFlashcards
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("permissions", new string[] { "Permission" }),
                new IdentityResource("roles", new[] { "role" })
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "angularClient",
                    ClientName = "Angular Client",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris = { "https://localhost:44379" },
                    PostLogoutRedirectUris = { "https://localhost:44379" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "permissions"
                    }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowOfflineAccess = true,
                    RequirePkce = false,

                    AlwaysSendClientClaims = true,
                    RequireConsent = false,

                    RedirectUris = { "https://localhost:44379/signin-oidc" },


                    PostLogoutRedirectUris = { "https://localhost:44379/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "api1",
                        "permissions"
                    }
                }
            };
    }
}
