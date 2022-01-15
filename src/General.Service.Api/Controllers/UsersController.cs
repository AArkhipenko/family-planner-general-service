using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace General.Service.Api.Controllers
{
    [Produces("application/json")]
    [Route("user/v10")]
    [ApiExplorerSettings(GroupName = "v10")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор <see cref="UsersController" />
        /// </summary>
        /// <param name="mediator"></param>
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
    }
}
