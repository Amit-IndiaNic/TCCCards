using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCCards.Identity.Identity
{
    public class CustomClientStore : IClientStore
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CustomClientStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var clients = new List<Client>
            {
                // Open API client
                new Client
                {
                    ClientId = "client",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets ={ new Secret("secret".Sha256()) },
                    
                    //AllowAccessTokensViaBrowser =true,
                    // scopes that client has access to
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequireConsent = false,
                    AccessTokenLifetime = 86400,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "IdentityServerApi"
                    }
                },

                // MVC Client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { $"{_configuration.GetValue<string>("Services:MVC")}signin-oidc" },

                    RequirePkce = true,
                    //AllowPlainTextPkce = false,
                    AllowOfflineAccess = true,
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { $"{_configuration.GetValue<string>("Services:MVC")}signout-callback-oidc" },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "IdentityServerApi"
                    },
                    //BackChannelLogoutSessionRequired = true,
                    
                    FrontChannelLogoutUri =  $"{_configuration.GetValue<string>("Services:MVC")}logoutcustom",
                },

                // Webform Client
                new Client
                {
                    ClientId = "webforms.owin.implicit",
                    //ClientSecrets = { new Secret("secret".Sha256()) },
                    ClientName = "ASPX Client",
                    AllowedGrantTypes = GrantTypes.Implicit,


                    RequirePkce = true,
                    AllowPlainTextPkce = false,

                    // where to redirect to after login
                    RedirectUris = { $"{_configuration.GetValue<string>("Services:LegacyCRM")}SSOCallback.aspx" },
                    
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { $"{_configuration.GetValue<string>("Services:LegacyCRM")}signout-callback-oidc" },
                    AllowAccessTokensViaBrowser = true,
                    //RequireConsent = false,
                    
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "IdentityServerApi"
                    },
                    FrontChannelLogoutUri =  $"{_configuration.GetValue<string>("Services:LegacyCRM")}Logout.aspx",
                }
            };

            var client = clients.FirstOrDefault(w => w.ClientId == clientId);
            return Task.FromResult(client);
        }
    }
}
