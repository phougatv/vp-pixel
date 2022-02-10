namespace VP.Pixel.WebAPI;

using VP.Pixel.Core.Persistence.Extensions;

public static class StartupExtension
{
    /// <summary>
    /// Adds services to the container during the startup of the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/></param>
    /// <returns></returns>
    internal static IServiceCollection AddPixelServices(this IServiceCollection services)
    {
        services.AddControllers();
        services
            .AddPersistence()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return services;
    }

    /// <summary>
    /// Configures the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The <see cref="ApplicationBuilder"/></param>
    /// <param name="env">The <see cref="IWebHostEnvironment"/></param>
    /// <param name="logger">The <see cref="ILogger"/></param>
    internal static void UseToConfigureRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
