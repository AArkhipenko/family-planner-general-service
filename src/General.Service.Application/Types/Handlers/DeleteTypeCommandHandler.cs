using General.Service.Application.Types.Commands;
using General.Service.Domain.Models;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DomainExt = General.Service.Domain.Models;

namespace General.Service.Application.Types.Handlers
{
    /// <summary>
    /// Выполнение запроса создания пользователя
    /// </summary>
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, Unit>
    {
        private readonly ITypeRepository _typeRepo;

        /// <summary>
        /// Конструктор <see cref="DeleteTypeCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с типами</param>
        public DeleteTypeCommandHandler(ITypeRepository typeRepo)
        {
            this._typeRepo = typeRepo ?? throw new ArgumentNullException(nameof(typeRepo));
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            await this._typeRepo.DeleteAsync(request.Id);
            return default;
        }
    }
}
