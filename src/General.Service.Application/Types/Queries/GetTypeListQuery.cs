using General.Service.Application.Types.DTO;
using MediatR;
using System.Collections.Generic;

namespace General.Service.Application.Types.Queries
{
    /// <summary>
    /// Запрос на получение списка типов
    /// </summary>
    public class GetTypeListQuery : IRequest<IAsyncEnumerable<TypeListDTO>>
    {
        /// <summary>
        /// Конструктор <see cref="GetTypeListQuery" />
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        /// <param name="code">код</param>
        public GetTypeListQuery(
            int offset,
            int count,
            string code)
        {
            this.Offset = offset;
            this.Count = count;
            this.Code = code;
        }

        /// <summary>
        /// Смещение (в кол-ве записей)
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Количество записей
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; }
    }
}
