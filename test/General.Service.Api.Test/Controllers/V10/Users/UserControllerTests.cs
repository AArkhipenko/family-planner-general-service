using AutoFixture;
using General.Service.Infrastructure.Database;
using General.Service.Infrastructure.Database.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class UserControllerTests
    {
        private readonly HttpClient _client;
        private readonly IWebHost _host;
        public UserControllerTests()
        {
            var server = new TestServer(
                new WebHostBuilder()
                .ConfigureTestServices(services =>
                {
                    var fixture = new Fixture();

                    var builder = new DbContextOptionsBuilder<FamilyPlannerContext>();
                    builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .EnableSensitiveDataLogging();

                    var options = builder.Options;
                    var context = new FamilyPlannerContext(options);
                    context.Database.EnsureCreated();
                    context.Database.EnsureDeleted();

                    context.Users.Add(
                        fixture
                            .Build<User>()
                            .Do(x=> x.Id = 1)
                            .Create());
                    context.Users.Add(
                        fixture
                            .Build<User>()
                            .Do(x => x.Id = 2)
                            .Create());
                    context.Users.Add(
                        fixture
                            .Build<User>()
                            .Do(x => x.Id = 3)
                            .Create());
                    context.SaveChanges();

                    services.AddSingleton(x => context);
                })
                .UseStartup<Startup>());

            _client = server.CreateClient();
            _host = server.Host;
        }
    }
}
