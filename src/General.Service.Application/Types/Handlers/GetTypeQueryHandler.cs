using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Queries;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace General.Service.Application.Types.Handlers
{
    /// <summary>
    /// Выполнение запроса получения списка пользователей
    /// </summary>
    public class GetTypeQueryHandler : IRequestHandler<GetTypeQuery, TypeDTO>
    {
        private readonly ITypeRepository _typeRepo;

        /// <summary>
        /// Конструктор <see cref="GetTypeQueryHandler" />
        /// </summary>
        /// <param name="typeRepo">репозиторий для работы с типами</param>
        public GetTypeQueryHandler(ITypeRepository typeRepo)
        {
            this._typeRepo = typeRepo ?? throw new ArgumentNullException(nameof(typeRepo));
        }

        /// <inheritdoc/>
        public async Task<TypeDTO> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            var member = await this._typeRepo.GetAsync(request.Id);
            return new TypeDTO
            {
                Id = member.Id,
                Name = member.Name,
                Code = member.Code
            };
        }
    }
}
