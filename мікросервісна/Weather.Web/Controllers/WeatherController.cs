using Microsoft.AspNetCore.Mvc;
using Weather.Web.Models;
using Weather.Web.Services;

namespace Weather.Web.Controllers;

public class WeatherController : Controller
{
    private readonly WeatherApiClient _api;

    public WeatherController(WeatherApiClient api)
    {
        _api = api;
    }

    [HttpGet]
    public IActionResult Index() => View(new WeatherViewModel());

    [HttpPost]
    public async Task<IActionResult> Result(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return View("Index", new WeatherViewModel { Error = "Введіть назву міста." });

        try
        {
            var result = await _api.GetWeatherAsync(city.Trim());
            if (result is null)
                return View("Index", new WeatherViewModel
                {
                    Error = "Не вдалося отримати дані. Перевірте місто або доступність сервісу."
                });

            return View(result);
        }
        catch (HttpRequestException)
        {
            return View("Index", new WeatherViewModel { Error = "Weather.Service недоступний." });
        }
    }
}
