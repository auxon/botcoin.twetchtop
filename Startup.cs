using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BotCoin.TwetchTop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            { 
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .WithOrigins("http://localhost:3007")
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            
            app.AddComponent<App>("app");
        }
    }
}
