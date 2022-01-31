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
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, int>
    {
        private readonly ITypeRepository _typeRepo;

        /// <summary>
        /// Конструктор <see cref="CreateTypeCommandHandler" />
        /// </summary>
        /// <param name="userRepo">репозиторий для работы с типами</param>
        public CreateTypeCommandHandler(ITypeRepository typeRepo)
        {
            this._typeRepo = typeRepo ?? throw new ArgumentNullException(nameof(typeRepo));
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            return await this._typeRepo.CreateAsync(new DomainExt.Type(
                request.Model.Name,
                request.Model.Code));
        }
    }
}
