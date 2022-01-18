using General.Service.Application.Users.DTO;
using MediatR;
using System.Collections.Generic;

namespace General.Service.Application.Users.Queries
{
    /// <summary>
    /// Запрос на получение информации по пользователю
    /// </summary>
    public class GetUserQuery : IRequest<UserDTO>
    {
        /// <summary>
        /// Конструктор <see cref="GetUserQuery" />
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        public GetUserQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; }
    }
}
