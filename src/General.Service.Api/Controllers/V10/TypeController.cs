using General.Service.Application.Types.Commands;
using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Queries;
using General.Service.Application.Types.Validators;
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
    [Route("types/v10")]
    [ApiExplorerSettings(GroupName = "v10")]
    public class TypeController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор <see cref="TypeController" />
        /// </summary>
        /// <param name="mediator"><see cref="IMediator" /></param>
        public TypeController(IMediator mediator)
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
        [SwaggerOperation(Description = "Возвращает список типов с фильтрацией по коду")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IAsyncEnumerable<TypeListDTO>), Description = "Список типов")]
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

        /// <summary>
        /// Получение информации по типу
        /// </summary>
        /// <param name="id">ид типа</param>
        /// <returns>модель типа</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Description = "Возвращает информацию по типу")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TypeDTO), Description = "Информация по типу")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Не найдена запись")]
        public async Task<IActionResult> GetAsync([Required] int id)
        {
            if (id <= 0)
                throw new ArgumentException("Не указан идентификатор записи");

            var result = await this._mediator.Send(new GetTypeQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Добавление нового типа
        /// </summary>
        /// <param name="model">модель нового типа</param>
        /// <returns>идентификатор нового типа</returns>
        [HttpPost]
        [SwaggerOperation(Description = "Добавление нового типа")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Создание прошло удачно")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        public async Task<IActionResult> CreateAsync([FromBody][Required] CreateTypeDTO model)
        {
            var validator = new CreateTypeDTOValidator();
            var validateResult = await validator.ValidateAsync(model);

            if (!validateResult.IsValid)
                throw new ArgumentException(validateResult.ToString());

            var result = await this._mediator.Send(new CreateTypeCommand(model));
            return Ok(result);
        }

        /// <summary>
        /// Изменение существующего типа
        /// </summary>
        /// <param name="model">модель типа</param>
        /// <returns></returns>
        [HttpPatch]
        [SwaggerOperation(Description = "Изменение существующего типа")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Изменение прошло удачно")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Не найдена запись")]
        public async Task<IActionResult> UpdateAsync([FromBody][Required] UpdateTypeDTO model)
        {
            var validator = new UpdateTypeDTOValidator();
            var validateResult = await validator.ValidateAsync(model);

            if (!validateResult.IsValid)
                throw new ArgumentException(validateResult.ToString());

            await this._mediator.Send(new UpdateTypeCommand(model));
            return Ok();
        }

        /// <summary>
        /// Удаление типа
        /// </summary>
        /// <param name="id">ид типа</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Description = "Удаление существующего типа")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Удаление прошло удачно")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Не найдена запись")]
        public async Task<IActionResult> DeleteAsync([Required] int id)
        {
            if (id <= 0)
                throw new ArgumentException("Не указан идентификатор записи");

            await this._mediator.Send(new DeleteTypeCommand(id));
            return Ok();
        }
    }
}
