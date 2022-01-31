using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Queries;
using General.Service.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DomainExt = General.Service.Domain.Models;

namespace General.Service.Application.Types.Handlers
{
    /// <summary>
    /// Выполнение запроса получения списка пользователей
    /// </summary>
    public class GetTypeListQueryHandler: IRequestHandler<GetTypeListQuery, IAsyncEnumerable<TypeListDTO>>
    {
        private readonly ITypeRepository _typeRepo;

        /// <summary>
        /// Конструктор <see cref="GetTypeListQueryHandler" />
        /// </summary>
        /// <param name="typeRepo">репозиторий для работы с типами</param>
        public GetTypeListQueryHandler(ITypeRepository typeRepo)
        {
            this._typeRepo = typeRepo ?? throw new ArgumentNullException(nameof(typeRepo));
        }

        /// <inheritdoc/>
        public async Task<IAsyncEnumerable<TypeListDTO>> Handle(GetTypeListQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Code))
            {
                var list = this._typeRepo.GetListByCodeAsync(request.Offset, request.Count, request.Code);
                return this.MapDataAsync(list);
            }
            return null;
        }

        /// <summary>
        /// Отображение доменной модели на модель ответа
        /// </summary>
        /// <param name="data">асинхронный список доменных записей</param>
        /// <returns>асинхронный список моделей ответа</returns>
        private async IAsyncEnumerable<TypeListDTO> MapDataAsync(IAsyncEnumerable<DomainExt.Type> data)
        {
            await foreach(var member in data)
            {
                yield return new TypeListDTO
                {
                    Id = member.Id,
                    Name = member.Name,
                    Code = member.Code
                };
            }
        }
    }
}
