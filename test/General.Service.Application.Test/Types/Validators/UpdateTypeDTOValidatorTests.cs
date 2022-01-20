using FluentValidation.TestHelper;
using General.Service.Application.Types.DTO;
using General.Service.Application.Types.Validators;
using Xunit;

namespace General.Service.Application.Test.Types.Validators
{
    public class UpdateTypeDTOValidatorTests : CreateTypeDTOValidatorTests
    {
        [Fact]
        public void Update_user_validation_has_id_error()
        {
            var model = new CreateTypeDTO
            {
                Id = -1,
                Name = "test",
                Code = "test_code"
            };

            var validator = new UpdateTypeDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
