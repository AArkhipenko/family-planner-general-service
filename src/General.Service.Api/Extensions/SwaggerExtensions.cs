using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace General.Service.Api.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Настройка и добавление Swagger в коллекцию <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />
        /// </summary>
        /// <param name="services"><see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /></param>
        public static void PrepareAndAddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v10", new OpenApiInfo { Title = Consts.ServiceTitle, Version = "1.0", Description = "Сервис для работы с основной информацией v1.0." });

                var xmlDoc = Path.ChangeExtension(System.Reflection.Assembly.GetEntryAssembly().Location, "xml");
                if(File.Exists(xmlDoc))
                {
                    c.IncludeXmlComments(xmlDoc);
                }

                c.UseInlineDefinitionsForEnums();

                c.EnableAnnotations();
            });
        }

        public static void PrepareAndUseSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
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
