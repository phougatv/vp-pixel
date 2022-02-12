using VP.Pixel.WebAPI;
using static VP.Pixel.WebAPI.Extension;

var builder = CreatePixelBuilder();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseItToConfigurePixelRequestPipeline();

app.Run();
