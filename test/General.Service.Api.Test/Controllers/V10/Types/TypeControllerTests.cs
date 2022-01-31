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
using InfraExt = General.Service.Infrastructure.Database.Tables;

namespace General.Service.Api.Test.Controllers.V10
{
    public partial class TypeControllerTests
    {
        private readonly HttpClient _client;
        private readonly IWebHost _host;
        public TypeControllerTests()
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

                    context.Types.Add(
                        fixture
                            .Build<InfraExt.Type>()
                            .Do(x=> x.Id = 1)
                            .Do(x=>x.Code = "code1")
                            .Create());
                    context.Types.Add(
                        fixture
                            .Build<InfraExt.Type>()
                            .Do(x => x.Id = 2)
                            .Do(x => x.Code = "code1")
                            .Create());
                    context.Types.Add(
                        fixture
                            .Build<InfraExt.Type>()
                            .Do(x => x.Id = 3)
                            .Do(x => x.Code = "code2")
                            .Create());
                    context.Types.Add(
                        fixture
                            .Build<InfraExt.Type>()
                            .Do(x => x.Id = 4)
                            .Do(x => x.Code = "code2")
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
