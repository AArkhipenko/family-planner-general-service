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
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, Unit>
    {
        private readonly ITypeRepository _typeRepo;

        /// <summary>
        /// Конструктор <see cref="CreateTypeCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с типами</param>
        public UpdateTypeCommandHandler(ITypeRepository typeRepo)
        {
            this._typeRepo = typeRepo ?? throw new ArgumentNullException(nameof(typeRepo));
        }

        /// <inheritdoc/>
        public async Task<Unit> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            await this._typeRepo.UpdateAsync(new DomainExt.Type(
                request.Model.Id,
                request.Model.Name,
                request.Model.Code));
            return default;
        }
    }
}
