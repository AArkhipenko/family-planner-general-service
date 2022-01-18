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
    }
}
