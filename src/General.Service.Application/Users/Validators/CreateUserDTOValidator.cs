using FluentValidation;
using General.Service.Application.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Application.Users.Validators
{
    /// <summary>
    /// Валидатор данных для создания пользователя
    /// </summary>
    public class CreateUserDTOValidator : AbstractValidator<UserDTO>
    {
        /// <summary>
        /// Конструктор <see cref="CreateUserDTOValidator" />
        /// </summary>
        public CreateUserDTOValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Имя обязательно к заполнению");

            RuleFor(t => t.Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Фамилия обязательна к заполнению");

            RuleFor(t => t.Birthday)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18))
                .WithMessage("Возраст пользователя должен быть не меньше 18 лет");
        }
    }
}
