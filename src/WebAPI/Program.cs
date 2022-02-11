using VP.Pixel.WebAPI;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions());
builder.Host.ConfigureAppConfiguration(
    (hostingContext, config) => config
    .AddJsonFile("./Json/appsettings.json", true, true)
    .AddJsonFile($"./Json/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development" }.json", true, true));

// Add services to the container.
builder.Services.AddPixelServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseItToConfigureRequestPipeline();

app.Run();
