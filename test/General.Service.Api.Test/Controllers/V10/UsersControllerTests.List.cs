﻿using AutoFixture;
using General.Service.Application.Users.DTO;
using General.Service.Infrastructure.Database;
using General.Service.Infrastructure.Database.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class UsersControllerTests
    {
        [Fact]
        public async Task Get_users_list_has_not_errors()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "0";
            query["count"] = "10";

            // Act
            var response = await _client.GetAsync($"/user/v10/list?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.ReadJsonAsync<IEnumerable<UserListDTO>>();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Get_users_list_has_offset_BagRequest_error()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "-1";
            query["count"] = "10";

            // Act
            var response = await _client.GetAsync($"/user/v10/list?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_users_list_has_count_BagRequest_error()
        {
            // Arrage
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["offset"] = "0";
            query["count"] = "0";

            // Act
            var response = await _client.GetAsync($"/user/v10/list?{query.ToString()}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}