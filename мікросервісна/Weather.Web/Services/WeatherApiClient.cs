using System.Net.Http.Json;
using Weather.Web.Models;

namespace Weather.Web.Services;

public class WeatherApiClient
{
    private readonly HttpClient _http;

    public WeatherApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<WeatherViewModel?> GetWeatherAsync(string city)
    {
        var url = $"api/weather?city={Uri.EscapeDataString(city)}";

        using var response = await _http.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<WeatherViewModel>();
    }
}
