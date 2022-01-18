using FluentValidation;

namespace General.Service.Application.Users.Validators
{
    /// <summary>
    /// Валидатор данных для изменения пользователя
    /// </summary>
    public class UpdateUserDTOValidator : CreateUserDTOValidator
    {
        /// <summary>
        /// Конструктор <see cref="UpdateUserDTOValidator" />
        /// </summary>
        public UpdateUserDTOValidator() : base()
        {
            RuleFor(t => t.Id)
                .GreaterThan(0)
                .WithMessage("Идентификатор записи больше нуля");
        }
    }
}
