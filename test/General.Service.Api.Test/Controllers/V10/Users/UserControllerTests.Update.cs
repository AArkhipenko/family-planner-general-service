using General.Service.Application.Users.DTO;
using General.Service.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class UserControllerTests
    {
        [Fact]
        public async Task Update_user_has_not_errors()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = 1,
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };
            var context = _host.Services.GetService<FamilyPlannerContext>();

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var member = await context.Users.FindAsync(model.Id);
            Assert.Equal(member.Name, model.Name);
            Assert.Equal(member.Surname, model.Surname);
            Assert.Equal(member.Birthday, model.Birthday);
        }

        [Fact]
        public async Task Update_user_has_id_BadRequest_error()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = -1,
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_user_has_id_NotFound_error()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = 999,
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Update_user_has_name_BadRequest_error()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = 1,
                Name = string.Empty,
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_user_has_surname_BadRequest_error()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = 1,
                Name = "test",
                Surname = string.Empty,
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_user_has_birthday_BadRequest_error()
        {
            // Arrage
            var model = new UpdateUserDTO
            {
                Id = 1,
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now
            };

            // Act
            var response = await _client.PatchAsync($"/users/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
