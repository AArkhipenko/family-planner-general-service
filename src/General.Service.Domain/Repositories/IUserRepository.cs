using General.Service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Service.Domain.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для работы с пользователями
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        /// <returns>асинхронный список пользователей</returns>
        IAsyncEnumerable<User> GetListAsync(int offset, int count);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="model">данные пользователя</param>
        /// <returns>идентификатор записи</returns>
        Task<int> CreateAsync(User model);

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="model">данные пользователя</param>
        /// <returns></returns>
        Task UpdateAsync(User model);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
