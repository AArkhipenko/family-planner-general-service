using General.Service.Application.Types.DTO;
using MediatR;
using System.Collections.Generic;

namespace General.Service.Application.Types.Queries
{
    /// <summary>
    /// Запрос на получение информации по типу
    /// </summary>
    public class GetTypeQuery : IRequest<TypeDTO>
    {
        /// <summary>
        /// Конструктор <see cref="GetTypeQuery" />
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        public GetTypeQuery(
            int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; }
    }
}
