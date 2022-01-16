using FluentValidation.TestHelper;
using General.Service.Application.Users.DTO;
using General.Service.Application.Users.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Application.Test.Users.Validators
{
    public class CreateUserDTOValidatorTests
    {
        [Fact]
        public void Create_user_validation_has_not_errors()
        {
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            var validator = new CreateUserDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Create_user_validation_has_name_error()
        {
            var model = new CreateUserDTO
            {
                Name = string.Empty,
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            var validator = new CreateUserDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);

            model.Name = null;
            result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Create_user_validation_has_surname_error()
        {
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = string.Empty,
                Birthday = DateTime.Now.AddYears(-18)
            };

            var validator = new CreateUserDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Surname);

            model.Surname = null;
            result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void Create_user_validation_has_birthday_error()
        {
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = string.Empty,
                Birthday = DateTime.Now
            };

            var validator = new CreateUserDTOValidator();
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Birthday);
        }
    }
}
