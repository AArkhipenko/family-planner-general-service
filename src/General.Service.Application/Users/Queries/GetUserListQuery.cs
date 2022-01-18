using General.Service.Application.Users.DTO;
using MediatR;
using System.Collections.Generic;

namespace General.Service.Application.Users.Queries
{
    /// <summary>
    /// Запрос на получение списка пользователей
    /// </summary>
    public class GetUserListQuery : IRequest<IAsyncEnumerable<UserListDTO>>
    {
        /// <summary>
        /// Конструктор <see cref="GetUserListQuery" />
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        public GetUserListQuery(
            int offset,
            int count)
        {
            this.Offset = offset;
            this.Count = count;
        }

        /// <summary>
        /// Смещение (в кол-ве записей)
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Количество записей
        /// </summary>
        public int Count { get; }
    }
}
