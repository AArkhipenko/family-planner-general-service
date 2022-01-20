using General.Service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Service.Domain.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для работы с типами
    /// </summary>
    public interface ITypeRepository
    {
        /// <summary>
        /// Получение списка типов отфильтрованных по коду
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        /// <param name="code">код</param>
        /// <returns>асинхронный типов</returns>
        IAsyncEnumerable<Type> GetListByCodeAsync(int offset, int count, string code);

        /// <summary>
        /// Получение информации по типу
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>данные по типу</returns>
        Task<Type> GetAsync(int id);

        /// <summary>
        /// Создание нового типа
        /// </summary>
        /// <param name="model">модель нового типа</param>
        /// <returns>идентификатор новой записи</returns>
        Task<int> CreateAsync(Type model);

        /// <summary>
        /// Обновление существующего типа
        /// </summary>
        /// <param name="model">модель для обновления типа</param>
        /// <returns></returns>
        Task UpdateAsync(Type model);

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id">ид записи</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
