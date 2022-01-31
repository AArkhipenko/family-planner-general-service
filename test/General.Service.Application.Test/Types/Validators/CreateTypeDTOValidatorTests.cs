using FluentValidation.TestHelper;
using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Validators;
using Xunit;

namespace General.Service.Application.Test.Types.Validators
{
    public class CreateTypeDTOValidatorTests
    {
        [Fact]
        public void Create_type_validation_has_not_errors()
        {
            var model = new CreateTypeDTO
            {
                Name = "test",
                Code = "test_code"
            };

            var validator = new CreateTypeDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Create_type_validation_has_name_error()
        {
            var model = new CreateTypeDTO
            {
                Name = string.Empty,
                Code = "test_code"
            };

            var validator = new CreateTypeDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);

            model.Name = null;
            result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Create_type_validation_has_code_error()
        {
            var model = new CreateTypeDTO
            {
                Name = "test",
                Code = string.Empty
            };

            var validator = new CreateTypeDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Code);

            model.Code = null;
            result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Code);
        }
    }
}
