using FluentValidation;

namespace General.Service.Application.Types.Validators
{
    /// <summary>
    /// Валидатор данных для изменения пользователя
    /// </summary>
    public class UpdateTypeDTOValidator : CreateTypeDTOValidator
    {
        /// <summary>
        /// Конструктор <see cref="UpdateTypeDTOValidator" />
        /// </summary>
        public UpdateTypeDTOValidator() : base()
        {
            RuleFor(t => t.Id)
                .GreaterThan(0)
                .WithMessage("Идентификатор записи должен быть больше нуля");
        }
    }
}
