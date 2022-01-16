using General.Service.Application.Users.Commands;
using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Queries;
using General.Service.Domain.Models;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace General.Service.Application.Users.Handlers
{
    /// <summary>
    /// Выполнение запроса изменения пользователя
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Конструктор <see cref="UpdateUserCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с пользователями</param>
        public UpdateUserCommandHandler(IUserRepository userRepo)
        {
            this._userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await this._userRepo.UpdateAsync(new User(
                request.Model.Id,
                request.Model.Name,
                request.Model.Surname,
                request.Model.Birthday));
            return Unit.Value;
        }
    }
}
