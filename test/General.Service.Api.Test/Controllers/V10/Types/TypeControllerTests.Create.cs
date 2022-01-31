using General.Service.Application.Types.DTO;
using General.Service.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class TypeControllerTests
    {
        [Fact]
        public async Task Create_type_has_not_errors()
        {
            // Arrage
            var model = new CreateTypeDTO
            {
                Name = "test",
                Code = "test_code"
            };
            var context = _host.Services.GetService<FamilyPlannerContext>();

            // Act
            var response = await _client.PostAsJsonAsync<CreateTypeDTO>($"/types/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var newId = (long)(await response.ReadJsonAsync<object>());
            var member = await context.Types.FindAsync((int)newId);
            Assert.NotNull(member);
        }

        [Fact]
        public async Task Create_type_has_name_BadRequest_error()
        {
            // Arrage
            var model = new CreateTypeDTO
            {
                Name = string.Empty,
                Code = "test_code"
            };

            // Act
            var response = await _client.PostAsJsonAsync<CreateTypeDTO>($"/types/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_type_has_code_BadRequest_error()
        {
            // Arrage
            var model = new CreateTypeDTO
            {
                Name = "test",
                Code = string.Empty
            };

            // Act
            var response = await _client.PostAsJsonAsync<CreateTypeDTO>($"/types/v10", model);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
