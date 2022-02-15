namespace VP.Pixel.Shared.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Shared.Persistence.Base;
using VP.Pixel.Shared.Persistence.Base.Concretes;

public static class Extension
{
    public static IServiceCollection AddPixelSharedPersistence<TContext>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TContext : DbContext
    {
        services
            .AddPixelDbContext<TContext>(configuration)
            .AddPixelUnitOfWork<TContext>(configuration);

        return services;
    }

    public static IServiceCollection AddPixelDbContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TContext : DbContext
    {
        var connectionString = configuration
            .GetSection("ConnectionStrings")
            .Get<IDictionary<String, String>>()["VP.Pixel"];

        services.AddDbContext<TContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection AddPixelUnitOfWork<TContext>(this IServiceCollection services, IConfiguration configuration)
        where TContext : DbContext
    {
        services
            .AddScoped<UnitOfWork<TContext>>()
            .AddScoped<IUnitOfWorkDbContext<TContext>>(s => s.GetRequiredService<UnitOfWork<TContext>>())
            .AddScoped<IUnitOfWork>(s => s.GetRequiredService<UnitOfWork<TContext>>());

        return services;
    }
}
