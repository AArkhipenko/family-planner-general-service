using AutoFixture;
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
        private readonly HttpClient _client;
        private readonly IWebHost _host;
        public UsersControllerTests()
        {
            var server = new TestServer(
                new WebHostBuilder()
                .ConfigureTestServices(services =>
                {
                    var fixture = new Fixture();

                    var builder = new DbContextOptionsBuilder<FamilyPlannerContext>();
                    builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .EnableSensitiveDataLogging();

                    var options = builder.Options;
                    var context = new FamilyPlannerContext(options);
                    context.Database.EnsureCreated();
                    context.Database.EnsureDeleted();

                    context.Users.AddRange(fixture.CreateMany<User>());
                    context.SaveChanges();

                    services.AddSingleton(x => context);
                })
                .UseStartup<Startup>());

            _client = server.CreateClient();
            _host = server.Host;
        }
    }
}
