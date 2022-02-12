namespace VP.Pixel.WebAPI;

using VP.Pixel.Core.Persistence.Extensions;

public static class Extension
{
    #region WebApplication Extensions
    internal static WebApplicationBuilder CreatePixelBuilder()
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
        });

        builder.Configuration.AddPixelAppSettings(builder.Environment.EnvironmentName, "./Json/appsettings.json");
        builder.Services.AddPixelServices(builder.Configuration);

        return builder;
    }
    #endregion WebApplicationBuilder Extensions

    #region Startup Extensions
    /// <summary>Adds services to the container during the startup of the application</summary>
    /// <param name="services">The <see cref="IServiceCollection"/></param>
    /// <returns></returns>
    internal static void AddPixelServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services
            .AddPersistence(configuration)
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }

    /// <summary>Configures the HTTP request pipeline</summary>
    /// <param name="app">The <see cref="ApplicationBuilder"/></param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/></param>
    /// <param name="logger">The <see cref="ILogger"/></param>
    internal static void UseItToConfigurePixelRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI();
        }

        app
            .UseHttpsRedirection()
            .UseAuthorization();

        app.MapControllers();
    }
    #endregion Startup Extensions

    #region Configuration Extensions
    internal static void AddPixelAppSettings(
        this ConfigurationManager manager,
        String environmentName,
        String filePath)
    {
        manager
            .AddJsonFile($"{Path.ChangeExtension(filePath, "")}json", true, true)
            .AddJsonFile($"{Path.ChangeExtension(filePath, "")}{environmentName}.json", true, true);
    }
    #endregion Configuration Extensions
}
