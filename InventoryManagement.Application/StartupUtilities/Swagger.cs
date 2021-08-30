using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace InventoryManagement.Application.StartupUtilities
{
    public static class Swagger
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Inventory Management API Documentation",
                    Description = "Switch Web API",
                    TermsOfService = new Uri("https://www.mfuatnuroglu.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "M Fuat NUROGLU",
                        Email = "mfuatnuroglu@gmail.com",
                        Url = new Uri("https://www.mfuatnuroglu.com/")
                    }
                });
                c.AddSecurityDefinition("Bearer",
                  new OpenApiSecurityScheme
                  {
                      In = ParameterLocation.Header,
                      Description = "Please enter into field the word 'Bearer' following by space and JWT",
                      Name = "Authorization",
                      Type = SecuritySchemeType.ApiKey,
                      Scheme = "Bearer"
                  });
            });
        }

        public static void AddUseSwagger(this IApplicationBuilder app, string version)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", version);
            });
        }
    }
}
