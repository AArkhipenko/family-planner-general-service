using General.Service.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Dynamic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace General.Service.Api.Middlewares
{
    internal class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next.Invoke(context);
            }
            catch (Exception ex)
            {
                //Статус ответа
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                //Получение ошибок со всеми уровнями вложенности
                var errorObject = await ReadFullExceptionAsync(ex, true);

                if (ex is NotFoundException)
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                this._logger.LogError(ex, string.Empty);

                await context.Response.WriteAsJsonAsync(errorObject);
            }
        }

        /// <summary>
        /// Рекурсивная функция получения всех вложенных ошибок
        /// </summary>
        /// <param name="ex">верхняя ошибка</param>
        /// <param name="isFirst">флаг нулевого уровня вложенности</param>
        /// <returns>Дерево ошибок</returns>
        private async Task<ExceptionResponseContent> ReadFullExceptionAsync(Exception ex, bool isFirst = false)
        {
            var result = new ExceptionResponseContent
            {
                ErrorMessage = ex.Message
            };
            if (isFirst)
                result.StackTrace = ex.StackTrace;
            if (ex.InnerException is not null)
                result.InnerException = await ReadFullExceptionAsync(ex.InnerException);
            return result;
        }
    }
}
