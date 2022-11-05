using Loymark.Core.Interfaces;
using Loymark.Infrastructure.Repositories;
using Loymark.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Helpers.Errors;

namespace WEBAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
                        .AllowAnyMethod()          //WithMethods("GET","POST")
                        .AllowAnyHeader());        //WithHeaders("accept","content-type")
                });
        
        public static void AddAplicacionServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        
        public static void AddValidationErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    string[] errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                        .SelectMany(u => u.Value.Errors)
                                                        .Select(u => u.ErrorMessage).ToArray();

                    ApiValidation errorResponse = new ApiValidation() { Errors = errors };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }

    }
}
