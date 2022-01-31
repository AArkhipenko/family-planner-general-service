using FluentValidation.TestHelper;
using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Validators;
using System;
using Xunit;

namespace General.Service.Application.Test.Users.Validators
{
    public class UpdateUserDTOValidatorTests : CreateUserDTOValidatorTests
    {
        [Fact]
        public void Update_user_validation_has_id_error()
        {
            var model = new CreateUserDTO
            {
                Id = -1,
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            var validator = new UpdateUserDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
