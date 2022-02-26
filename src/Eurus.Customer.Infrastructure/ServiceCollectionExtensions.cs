using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weasel.Core;

namespace Eurus.Customer.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void RegisterInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.AddMarten(opt =>
        {
            opt.Connection(configuration.GetConnectionString("Customer"));

            opt.Schema.For<Eurus.Customer.Domain.Aggregates.Customer>()
                .Identity(x => x.AggregateId);

            opt.UseDefaultSerialization(nonPublicMembersStorage: NonPublicMembersStorage.All);

            if (environment.IsDevelopment())
            {
                opt.AutoCreateSchemaObjects = AutoCreate.All;
            }
        });
    }
}