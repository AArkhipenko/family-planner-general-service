using General.Service.Application.Users.DTO;
using MediatR;

namespace General.Service.Application.Users.Commands
{
    /// <summary>
    /// Запрос изменения пользователя
    /// </summary>
    public class UpdateUserCommand : IRequest
    {
        /// <summary>
        /// Конструктор <see cref="UpdateUserCommand" />
        /// </summary>
        /// <param name="model">модель для изменения пользователя</param>
        public UpdateUserCommand(UserDTO model)
        {
            this.Model = model;
        }

        /// <summary>
        /// Модель для изменения пользователя
        /// </summary>
        public UserDTO Model { get; }
    }
}
