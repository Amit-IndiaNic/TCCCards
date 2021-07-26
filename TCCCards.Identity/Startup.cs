using IdentityServer4.Configuration;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Identity.Data;
using TCCCards.Identity.Identity;

namespace TCCCards.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddMvc();

            services.AddIdentityServer(options =>
            {
                options.UserInteraction = new UserInteractionOptions()
                {
                    LogoutUrl = "/account/logout",
                    LoginUrl = "/account/login",
                    LoginReturnUrlParameter = "returnUrl"
                };
            })
                    .AddDeveloperSigningCredential()
                    .AddResourceStore<CustomResourceStore>()
                    //.AddInMemoryApiResources(Config.Apis)
                    .AddClientStore<CustomClientStore>()
                    .AddProfileService<ProfileService>()
                    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                    ;



            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<CustomUserService>();
            services.AddDbContext<TCCContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
