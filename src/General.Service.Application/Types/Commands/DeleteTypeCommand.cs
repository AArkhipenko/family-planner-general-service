using General.Service.Application.Types.DTO;
using MediatR;

namespace General.Service.Application.Types.Commands
{
    /// <summary>
    /// Запрос удаления типа
    /// </summary>
    public class DeleteTypeCommand : IRequest
    {
        /// <summary>
        /// Конструктор <see cref="DeleteTypeCommand" />
        /// </summary>
        /// <param name="id">ид записи</param>
        public DeleteTypeCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Ид записи
        /// </summary>
        public int Id { get; }
    }
}
