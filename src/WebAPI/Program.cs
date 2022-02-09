using VP.Pixel.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPixelServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseToConfigureRequestPipeline();

app.Run();
