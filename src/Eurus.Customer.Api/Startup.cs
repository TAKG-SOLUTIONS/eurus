using Eurus.Customer.Infrastructure;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

namespace Eurus.Customer.Api;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddServiceDiscovery(opt =>
        {
            opt.UseConsul();
        });
      
        
        services.AddRazorPages();

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
            // c.CustomSchemaIds(schema => schema.FullName);
            c.EnableAnnotations();
        });
        
        services.RegisterInfrastructureServices(Configuration, Environment);
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // app.UseSerilogRequestLogging();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    } 
}