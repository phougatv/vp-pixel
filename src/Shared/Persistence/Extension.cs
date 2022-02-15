namespace VP.Pixel.Shared.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Shared.Persistence.Base;
using VP.Pixel.Shared.Persistence.Base.Concretes;

public static class Extension
{
    public static IServiceCollection AddPixelSharedPersistence<TContext>(this IServiceCollection services)
        where TContext : DbContext
        => services.AddPixelUnitOfWork<TContext>();

    internal static IServiceCollection AddPixelUnitOfWork<TContext>(this IServiceCollection services)
        where TContext : DbContext
        => services
            .AddScoped<UnitOfWork<TContext>>()
            .AddScoped<IUnitOfWorkDbContext<TContext>>(s => s.GetRequiredService<UnitOfWork<TContext>>())
            .AddScoped<IUnitOfWork>(s => s.GetRequiredService<UnitOfWork<TContext>>());
}
