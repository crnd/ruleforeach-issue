using BookshelfManager.Bookshelves;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace BookshelfManager
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation();

            services
                .AddTransient<IValidator<CreateBookshelfCommand>, CreateBookshelfCommandValidator>()
                .AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo { Title = "BookshelfManager", Version = "v1" });
                    o.AddFluentValidationRules();
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookshelfManager"))
                .UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
