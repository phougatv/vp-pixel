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

builder.Services
    //.AddDbContext<PixelDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(connectionString))
    //.AddPixelUnitOfWork<PixelDbContext>(builder.Configuration)
    .AddPixelSharedPersistence<AppDbContext>(builder.Configuration)
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
