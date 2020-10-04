using Refit;
using hackernewsapi.Services;
using hackernewsapi.Services.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using hackernewsapi.Profiles;
using System.Diagnostics.CodeAnalysis;

namespace hackernewsapi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHackerNewsService, HackerNewsService>();
            services.AddRefitClient<IHackerNewsApi>().ConfigureHttpClient(
                c => c.BaseAddress = new Uri(Configuration["HackerNewsBaseApi"])
            );
            services.AddAutoMapper(typeof(HackerNewsProfile));
        }

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
