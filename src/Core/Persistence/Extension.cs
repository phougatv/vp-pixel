﻿namespace VP.Pixel.Core.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Core.Persistence.User;

public static class Extension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .AddDbContext<UserDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VP.Pixel;Integrated Security=SSPI;Trusted_Connection=True"))
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
