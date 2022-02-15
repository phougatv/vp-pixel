namespace VP.Pixel.Core.Persistence.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Core.Persistence.Base;
using VP.Pixel.Core.Persistence.Base.Concretes;
using VP.Pixel.Core.Persistence.DbContext;
using VP.Pixel.Core.Persistence.User;

public static class Extension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetSection("ConnectionStrings")
            .Get<IDictionary<String, String>>()["VP.Pixel"];

        services
            .AddDbContext<PixelDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(connectionString))
            .AddScoped<UnitOfWork>()
            .AddScoped<IUnitOfWorkDbContext<PixelDbContext>>(s => s.GetRequiredService<UnitOfWork>())
            .AddScoped<IUnitOfWork>(s => s.GetRequiredService<UnitOfWork>())
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
