using FluentValidation;
using General.Service.Application.Types.DTO;
using System;

namespace General.Service.Application.Types.Validators
{
    /// <summary>
    /// Валидатор данных для создания нового типа
    /// </summary>
    public class CreateTypeDTOValidator : AbstractValidator<TypeDTO>
    {
        /// <summary>
        /// Конструктор <see cref="CreateTypeDTOValidator" />
        /// </summary>
        public CreateTypeDTOValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Наименование обязательно к заполнению");

            RuleFor(t => t.Code)
                .NotEmpty()
                .NotNull()
                .WithMessage("Код обязателен к заполнению");
        }
    }
}
