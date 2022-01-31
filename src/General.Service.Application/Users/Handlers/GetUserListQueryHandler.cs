using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Queries;
using General.Service.Domain.Models;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace General.Service.Application.Users.Handlers
{
    /// <summary>
    /// Выполнение запроса получения списка пользователей
    /// </summary>
    public class GetUserListQueryHandler: IRequestHandler<GetUserListQuery, IAsyncEnumerable<UserListDTO>>
    {
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Конструктор <see cref="GetUserListQueryHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с пользователями</param>
        public GetUserListQueryHandler(IUserRepository userRepo)
        {
            this._userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<UserListDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var list = this._userRepo.GetListAsync(request.Offset, request.Count);
            return this.MapDataAsync(list);
        }

        /// <summary>
        /// Отображение доменной модели на модель ответа
        /// </summary>
        /// <param name="data">асинхронный список доменных записей</param>
        /// <returns>асинхронный список моделей ответа</returns>
        private async IAsyncEnumerable<UserListDTO> MapDataAsync(IAsyncEnumerable<User> data)
        {
            await foreach(var member in data)
            {
                yield return new UserListDTO
                {
                    Id = member.Id,
                    Name = member.Name,
                    Surname = member.Surname,
                    Birthday = member.Birthday
                };
            }
        }
    }
}
