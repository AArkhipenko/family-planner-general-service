using General.Service.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace General.Service.Infrastructure.Database.Repositories
{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    internal class BaseRepository
    {
        protected readonly FamilyPlannerContext _context;

        /// <summary>
        /// Конструктор <see cref="BaseRepository" />
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public BaseRepository(FamilyPlannerContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Поиск записи по ид
        /// </summary>
        /// <param name="id">ид записи</param>
        /// <returns>данные по записи</returns>
        protected async Task<TEntity> GetMemberAsync<TEntity>(int id)
            where TEntity : class
        {
            var result = await this._context.FindAsync<TEntity>(id);
            if (result is null)
                throw new NotFoundException($"Запись с идентификатором {id} не найден");
            return result;
        }
    }
}
