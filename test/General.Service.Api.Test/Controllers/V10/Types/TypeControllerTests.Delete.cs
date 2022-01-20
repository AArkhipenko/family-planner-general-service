using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class TypeControllerTests
    {
        [Fact]
        public async Task Delete_type_has_not_errors()
        {
            // Arrage
            int id = 3;

            // Act
            var response = await _client.DeleteAsync($"/types/v10/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_type_has_id_BadRequest_error()
        {
            // Arrage
            int id = -1;

            // Act
            var response = await _client.DeleteAsync($"/types/v10/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_type_has_id_NotFound_error()
        {
            // Arrage
            int id = 999;

            // Act
            var response = await _client.DeleteAsync($"/types/v10/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
