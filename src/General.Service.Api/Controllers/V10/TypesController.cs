using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace General.Service.Api.Controllers.V10
{
    /// <summary>
    /// Контроллер для получения информации по пользователям
    /// </summary>
    [Produces("application/json")]
    [Route("type/v10")]
    [ApiExplorerSettings(GroupName = "v10")]
    public class TypesController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор <see cref="TypesController" />
        /// </summary>
        /// <param name="mediator"><see cref="IMediator" /></param>
        public TypesController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Списка типов с фильтрацией по коду
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        /// <param name="code">код типа</param>
        /// <returns>Список типов</returns>
        [HttpGet("list_by_code")]
        [SwaggerOperation(Description = "Возвращает список пользователей")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IAsyncEnumerable<TypeListDTO>), Description = "Список пользователей")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        public async Task<IActionResult> GetListByCodeAsync(
            [FromQuery] int offset = 0,
            [FromQuery] int count = 10,
            [FromQuery] string code = null)
        {
            if (offset < 0)
                throw new ArgumentException("Смещение не может быть меньше ноля");
            if(count <= 0)
                throw new ArgumentException("Количество записей должно быть больше ноля");
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("Код обязателен для заполнения");

            var result = await this._mediator.Send(new GetTypeListQuery(offset, count, code));
            return Ok(result);
        }
    }
}
