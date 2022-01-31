using General.Service.Application.Types.DTO;
using MediatR;

namespace General.Service.Application.Types.Commands
{
    /// <summary>
    /// Запрос обновления типа
    /// </summary>
    public class UpdateTypeCommand : IRequest
    {
        /// <summary>
        /// Конструктор <see cref="CreateTypeCommand" />
        /// </summary>
        /// <param name="model">модель для обновления типа</param>
        public UpdateTypeCommand(TypeDTO model)
        {
            this.Model = model;
        }

        /// <summary>
        /// Модель для обновления типа
        /// </summary>
        public TypeDTO Model { get; }
    }
}
