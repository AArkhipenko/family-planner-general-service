using General.Service.Domain.Repositories;
using General.Service.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace General.Service.Infrastructure.Database
{
    /// <summary>
    /// Расширения связанные с БД
    /// </summary>
    public static class DatabaseExtentions
    {
        /// <summary>
        /// Добавление контекста
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /></param>
        /// <param name="options">настройки для подключения к БД</param>
        public static void AddDbContext(this IServiceCollection services, DatabaseOptions options)
        {
            services.AddDbContext<FamilyPlannerContext>(configurator =>
            {
                configurator.UseNpgsql($"Host={options.Address};" +
                    $"Port={options.Port};" +
                    $"Database={options.DatabaseName};" +
                    $"Username={options.Username};" +
                    $"Password={options.Password}");
            });
        }

        /// <summary>
        /// Добавление репозиторием в depedency injection
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
        }
    }
}
