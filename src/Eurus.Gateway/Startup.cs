using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Serilog;

namespace Eurus.Gateway;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        
       services.AddOcelot().AddConsul();
        
            
       services.AddControllers();
       services.AddEndpointsApiExplorer();
            
       services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSerilogRequestLogging();
        }
        
        app.UseHttpsRedirection();
            
        app.UseCors("CorsPolicy");
        
        app.UseAuthentication();
        
        app.UseOcelot();
    }
}