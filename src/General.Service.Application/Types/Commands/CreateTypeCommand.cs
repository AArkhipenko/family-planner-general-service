using General.Service.Application.Types.DTO;
using MediatR;

namespace General.Service.Application.Types.Commands
{
    /// <summary>
    /// Запрос создания нового типа
    /// </summary>
    public class CreateTypeCommand: IRequest<int>
    {
        /// <summary>
        /// Конструктор <see cref="CreateTypeCommand" />
        /// </summary>
        /// <param name="model">модель для создания нового типа</param>
        public CreateTypeCommand(TypeDTO model)
        {
            this.Model = model;
        }

        /// <summary>
        /// Модель для создания нового типа
        /// </summary>
        public TypeDTO Model { get; }
    }
}
