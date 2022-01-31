using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace General.Service.Api.Extensions
{
    /// <summary>
    /// Расширения связаннные с работой swagger
    /// </summary>
    internal static class SwaggerExtensions
    {
        /// <summary>
        /// Настройка и добавление Swagger в коллекцию <see cref="IServiceCollection" />
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /></param>
        internal static void PrepareAndAddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v10", new OpenApiInfo { Title = Consts.ServiceTitle, Version = "1.0", Description = "Сервис для работы с основной информацией v1.0." });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                if (File.Exists(xmlFilename))
                {
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                }

                options.UseInlineDefinitionsForEnums();
                options.EnableAnnotations();
            });
        }

        internal static void PrepareAndUseSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = string.Concat($"/{Consts.SwaggerRoutePrefix}", "/{documentName}/swagger.json");
            });

            app.UseSwaggerUI(c =>
            {
                c.DefaultModelExpandDepth(-1);
                c.DisplayRequestDuration();
                c.DocumentTitle = Consts.ServiceTitle;
                c.RoutePrefix = Consts.SwaggerRoutePrefix;
                c.SwaggerEndpoint($"/{Consts.SwaggerRoutePrefix}/v10/swagger.json", $"{Consts.ApiTitle} 1.0");
            });

            app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", $"{Consts.SwaggerRoutePrefix}/"));
        }
    }
}
