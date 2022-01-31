using General.Service.Application.Users.Commands;
using General.Service.Domain.Models;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace General.Service.Application.Users.Handlers
{
    /// <summary>
    /// Выполнение запроса создания пользователя
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepo;

        /// <summary>
        /// Конструктор <see cref="CreateUserCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с пользователями</param>
        public CreateUserCommandHandler(IUserRepository userRepo)
        {
            this._userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await this._userRepo.CreateAsync(new User(
                request.Model.Name,
                request.Model.Surname,
                request.Model.Birthday));
        }
    }
}
