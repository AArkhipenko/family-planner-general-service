using General.Service.Application.Users.Commands;
using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Queries;
using General.Service.Application.Users.Validators;
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
    [Route("user/v10")]
    [ApiExplorerSettings(GroupName = "v10")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор <see cref="UsersController" />
        /// </summary>
        /// <param name="mediator"><see cref="IMediator" /></param>
        public UsersController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <param name="offset">смещение (в количестве записей)</param>
        /// <param name="count">количество записей</param>
        /// <returns>Список пользователей</returns>
        [HttpGet("list")]
        [SwaggerOperation(Description = "Возвращает список пользователей")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IAsyncEnumerable<UserListDTO>), Description = "Список пользователей")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        public async Task<IActionResult> GetListAsync(
            [FromQuery] int offset = 0,
            [FromQuery] int count = 10)
        {
            if (offset < 0)
                throw new ArgumentException("Смещение не может быть меньше ноля");
            if(count <= 0)
                throw new ArgumentException("Количество записей должно быть больше ноля");

            var result = await this._mediator.Send(new GetUserListQuery(offset, count));
            return Ok(result);
        }


        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="model">модель пользователя</param>
        /// <returns>идентификатор пользователя</returns>
        [HttpPost]
        [SwaggerOperation(Description = "Добавление нового пользователя")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Создание прошло удачно")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        public async Task<IActionResult> CreateAsync([FromBody][Required] CreateUserDTO model)
        {
            var validator = new CreateUserDTOValidator();
            var validateResult = await validator.ValidateAsync(model);

            if (!validateResult.IsValid)
                throw new ArgumentException(validateResult.ToString());

            var result = await this._mediator.Send(new CreateUserCommand(model));
            return Ok(result);
        }

        /// <summary>
        /// Изменение существующего пользователя
        /// </summary>
        /// <param name="model">модель пользователя</param>
        /// <returns>идентификатор пользователя</returns>
        [HttpPatch]
        [SwaggerOperation(Description = "Изменение существующего пользователя")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, Description = "Изменение прошло удачно")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Неверно указаны параметры")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Не найдена запись пользователя")]
        public async Task<IActionResult> UpdateAsync([FromBody][Required] UpdateUserDTO model)
        {
            var validator = new UpdateUserDTOValidator();
            var validateResult = await validator.ValidateAsync(model);

            if (!validateResult.IsValid)
                throw new ArgumentException(validateResult.ToString());

            var result = await this._mediator.Send(new UpdateUserCommand(model));
            return NoContent();
        }
    }
}
