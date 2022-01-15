using Microsoft.Extensions.DependencyInjection;
using MediatR;
using General.Service.Application.Users.Queries;

namespace General.Service.Api.Extensions
{
    public static class MediatorExtensions
    {
        /// <summary>
        /// Настройка и добавление Swagger в коллекцию <see cref="IServiceCollection" />
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /></param>
        public static void AddMediators(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetUserListQuery));
        }
    }
}
