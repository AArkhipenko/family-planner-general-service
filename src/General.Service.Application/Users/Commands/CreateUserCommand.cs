using General.Service.Application.Users.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Application.Users.Commands
{
    /// <summary>
    /// Запрос создания пользователя
    /// </summary>
    public class CreateUserCommand: IRequest<int>
    {
        /// <summary>
        /// Конструктор <see cref="CreateUserCommand" />
        /// </summary>
        /// <param name="model">модель для создания пользователя</param>
        public CreateUserCommand(UserDTO model)
        {
            this.Model = model;
        }

        /// <summary>
        /// Модель для создания пользователя
        /// </summary>
        public UserDTO Model { get; }
    }
}
