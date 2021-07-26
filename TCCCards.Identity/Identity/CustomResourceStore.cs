using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCCards.Identity.Identity
{
    public class CustomResourceStore : IResourceStore
    {
        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var data = apiResources.Where(w => apiResourceNames.Contains(w.Name));
            return Task.FromResult(data.AsEnumerable());
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var data = apiResources.Where(w => scopeNames.Intersect(w.Scopes).Count() > 0);
            return Task.FromResult(data.AsEnumerable());
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var res = apiScopes.Where(w => scopeNames.Contains(w.Name));
            return Task.FromResult(res);
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult(identityResources.Where(s => scopeNames.Contains(s.Name)));
            //throw new NotImplementedException();
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var res = new Resources();
            res.IdentityResources = identityResources;
            res.ApiScopes = apiScopes;
            res.ApiResources = apiResources;
            return Task.FromResult(res);
            //throw new NotImplementedException();
        }

        private readonly List<IdentityResource> identityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone()
            };
        private readonly List<ApiResource> apiResources = new List<ApiResource>
        {
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        private readonly List<ApiScope> apiScopes = new List<ApiScope>
        {
            new ApiScope(name: "IdentityServerApi", displayName: "Access to API"),
            new ApiScope(name: "all", displayName: "Access to API")
        };
    }
}
