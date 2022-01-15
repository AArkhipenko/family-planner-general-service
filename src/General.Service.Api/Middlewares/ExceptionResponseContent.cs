using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace General.Service.Api.Middlewares
{
    /// <summary>
    /// Модель данных для ответа на запросы с исключениями
    /// </summary>
    internal class ExceptionResponseContent
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Путь возникновения исключения
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Внутренние исключения
        /// </summary>
        public ExceptionResponseContent InnerException { get; set; }
    }
}
