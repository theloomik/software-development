namespace Weather.Web.Models;

public class WeatherViewModel
{
    public string City { get; set; } = "";
    public string Description { get; set; } = "";
    public double Temperature { get; set; }
    public string Icon { get; set; } = "";
    public string? Error { get; set; }
}
