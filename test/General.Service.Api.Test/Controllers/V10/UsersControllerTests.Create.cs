using General.Service.Application.Users.DTO;
using General.Service.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class UsersControllerTests
    {
        [Fact]
        public async Task Create_user_has_not_errors()
        {
            // Arrage
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };
            var context = _host.Services.GetService<FamilyPlannerContext>();

            // Act
            var response = await _client.PostAsJsonAsync<CreateUserDTO>($"/user/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var newId = (long)(await response.ReadJsonAsync<object>());
            var member = await context.Users.FindAsync((int)newId);
            Assert.NotNull(member);
        }

        [Fact]
        public async Task Create_user_has_name_BadRequest_error()
        {
            // Arrage
            var model = new CreateUserDTO
            {
                Name = string.Empty,
                Surname = "test",
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PostAsJsonAsync<CreateUserDTO>($"/user/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_user_has_surname_BadRequest_error()
        {
            // Arrage
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = string.Empty,
                Birthday = DateTime.Now.AddYears(-18)
            };

            // Act
            var response = await _client.PostAsJsonAsync<CreateUserDTO>($"/user/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_user_has_birthday_BadRequest_error()
        {
            // Arrage
            var model = new CreateUserDTO
            {
                Name = "test",
                Surname = "test",
                Birthday = DateTime.Now
            };

            // Act
            var response = await _client.PostAsJsonAsync<CreateUserDTO>($"/user/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
