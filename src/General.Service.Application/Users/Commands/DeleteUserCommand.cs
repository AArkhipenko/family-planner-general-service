using MediatR;

namespace General.Service.Application.Users.Commands
{
    /// <summary>
    /// Запрос удаления пользователя
    /// </summary>
    public class DeleteUserCommand : IRequest
    {
        /// <summary>
        /// Конструктор <see cref="DeleteUserCommand" />
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Ид пользователя для удаления
        /// </summary>
        public int Id { get; }
    }
}
