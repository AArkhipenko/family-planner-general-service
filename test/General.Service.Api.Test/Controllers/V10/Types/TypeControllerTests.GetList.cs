using General.Service.Application.Types.DTO;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class TypeControllerTests
    {
        [Fact]
        public async Task Get_types_list_by_code_has_not_errors()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "0";
            query["count"] = "10";
            query["code"] = "code1";

            // Act
            var response = await _client.GetAsync($"/types/v10/list_by_code?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.ReadJsonAsync<IList<TypeListDTO>>();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Get_types_list_by_code_has_offset_BagRequest_error()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "-1";
            query["count"] = "10";
            query["code"] = "code1";

            // Act
            var response = await _client.GetAsync($"/types/v10/list_by_code?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_types_list_by_code_has_count_BagRequest_error()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "0";
            query["count"] = "0";
            query["code"] = "code1";

            // Act
            var response = await _client.GetAsync($"/types/v10/list_by_code?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_types_list_by_code_has_code_BagRequest_error()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "0";
            query["count"] = "0";
            query["code"] = string.Empty;

            // Act
            var response = await _client.GetAsync($"/types/v10/list_by_code?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
