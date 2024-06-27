using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieService.Application.Abstractions;
using MovieService.Application.Implementations;
using MovieService.Application.Messages;
using MovieService.Domain.DB;
using MovieService.Infrastructure.Abstraction;
using MovieService.Infrastructure.Implementation;
using System.Text.Json;

namespace MovieService.Presentation.Extension
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRegistration (this IServiceCollection service, ConfigurationManager configuration)
        {
            // Service Registration

            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IMovieServices, MovieServices>();

            var appSettingsSection = configuration.GetSection("AppSettings");
            service.Configure<AppSettings>(appSettingsSection);

            var respSettings = configuration.GetSection("ServiceResponseSettings");
            service.Configure<SuccessResponseService>(respSettings);

            service.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            service.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Service", Version = "v1" });
                
            });
            //Adding Cors Security Access
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("")
                .AllowAnyHeader()
                .WithMethods("POST", "GET", "PUT", "DELETE")
                .AllowCredentials()
                .Build());
            });

            return service;
        } 
    }
}
