using Microsoft.AspNetCore.Mvc;
using Weather.Service.Services;

namespace Weather.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherProvider _provider;

    public WeatherController(IWeatherProvider provider)
    {
        _provider = provider;
    }

    // GET /api/weather?city=Kyiv
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest(new { message = "Потрібно вказати місто." });

        try
        {
            var weather = await _provider.GetWeatherAsync(city.Trim());
            if (weather is null)
                return NotFound(new { message = "Не вдалося знайти погоду для цього міста." });

            return Ok(weather);
        }
        catch (HttpRequestException)
        {
            return StatusCode(502, new { message = "Зовнішній погодний сервіс недоступний." });
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
