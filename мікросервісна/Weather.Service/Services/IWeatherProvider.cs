using Weather.Service.Models;

namespace Weather.Service.Services;

public interface IWeatherProvider
{
    Task<WeatherResponse?> GetWeatherAsync(string city);
}
