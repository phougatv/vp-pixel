using Microsoft.EntityFrameworkCore;
using VP.Pixel.Shared.Persistence;
using VP.Pixel.WebAPI;
using VP.Pixel.WebAPI.Users.DataAccess;

//Add configuration & services to the DI container
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
});
builder.Configuration
    .AddJsonFile($"{Path.ChangeExtension("./Json/appsettings.json", "")}json", true, true)
    .AddJsonFile($"{Path.ChangeExtension("./Json/appsettings.json", "")}{builder.Environment.EnvironmentName}.json", true, true);

builder.Services
    .AddControllers();

var connectionString = builder.Configuration
            .GetSection("ConnectionStrings")
            .Get<IDictionary<String, String>>()["VP.Pixel"];

builder.Services
    .AddDbContext<AppDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(connectionString))
    .AddPixelSharedPersistence<AppDbContext>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
