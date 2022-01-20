using General.Service.Application.Types.DTO;
using General.Service.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class TypeControllerTests
    {
        [Fact]
        public async Task Update_type_has_not_errors()
        {
            // Arrage
            var model = new UpdateTypeDTO
            {
                Id = 1,
                Name = "test",
                Code = "test_code"
            };
            var context = _host.Services.GetService<FamilyPlannerContext>();

            // Act
            var response = await _client.PatchAsync($"/types/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var member = await context.Types.FindAsync(model.Id);
            Assert.Equal(member.Name, model.Name);
            Assert.Equal(member.Code, model.Code);
        }

        [Fact]
        public async Task Update_type_has_id_BadRequest_error()
        {
            // Arrage
            var model = new UpdateTypeDTO
            {
                Id = -1,
                Name = "test",
                Code = "test_code"
            };

            // Act
            var response = await _client.PatchAsync($"/types/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_type_has_id_NotFound_error()
        {
            // Arrage
            var model = new UpdateTypeDTO
            {
                Id = 999,
                Name = "test",
                Code = "test_code"
            };

            // Act
            var response = await _client.PatchAsync($"/types/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Update_type_has_name_BadRequest_error()
        {
            // Arrage
            var model = new UpdateTypeDTO
            {
                Id = 1,
                Name = string.Empty,
                Code = "test_code"
            };

            // Act
            var response = await _client.PatchAsync($"/types/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_type_has_code_BadRequest_error()
        {
            // Arrage
            var model = new UpdateTypeDTO
            {
                Id = 1,
                Name = "test",
                Code = string.Empty
            };

            // Act
            var response = await _client.PatchAsync($"/types/v10", model.ToHttpContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
