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
    /// Выполнение запроса удаления пользователя
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Конструктор <see cref="DeleteUserCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с пользователями</param>
        public DeleteUserCommandHandler(IUserRepository userRepo)
        {
            this._userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await this._userRepo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
