using System.Text.Json;
using Weather.Service.Models;

namespace Weather.Service.Services;

public class OpenWeatherProvider : IWeatherProvider
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public OpenWeatherProvider(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }

    public async Task<WeatherResponse?> GetWeatherAsync(string city)
    {
        var apiKey = _configuration["OpenWeather:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("Не налаштовано OpenWeather API key.");

        var url = "https://api.openweathermap.org/data/2.5/weather" +
                  $"?q={Uri.EscapeDataString(city)}&appid={apiKey}&units=metric&lang=uk";

        using var response = await _http.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;

        using var stream = await response.Content.ReadAsStreamAsync();
        using var json = await JsonDocument.ParseAsync(stream);
        var root = json.RootElement;

        return new WeatherResponse
        {
            City = root.GetProperty("name").GetString() ?? city,
            Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? "",
            Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
            Icon = root.GetProperty("weather")[0].GetProperty("icon").GetString() ?? ""
        };
    }
}
