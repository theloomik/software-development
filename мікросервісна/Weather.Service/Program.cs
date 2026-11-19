using Weather.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<IWeatherProvider, OpenWeatherProvider>();

var app = builder.Build();

app.MapControllers();

app.Run();
