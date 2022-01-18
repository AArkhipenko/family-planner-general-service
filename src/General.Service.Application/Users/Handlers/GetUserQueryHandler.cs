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
    /// Выполнение запроса получения информации по пользователю
    /// </summary>
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Конструктор <see cref="GetUserQueryHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с пользователями</param>
        public GetUserQueryHandler(IUserRepository userRepo)
        {
            this._userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        /// <inheritdoc/>
        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var list = await this._userRepo.GetAsync(request.Id);
            return new UserDTO
            {
                Id = list.Id,
                Name = list.Name,
                Surname = list.Surname,
                Birthday = list.Birthday
            };
        }
    }
}
