using AspireDemo.Api.Domain.Forecasts;

namespace AspireDemo.Api.Application.Weather;

public sealed class ForecastService : IForecastService
{
    private static readonly string[] Summaries =
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching",
    };

    public IEnumerable<Forecast> GetForecast(int days) =>
        Enumerable
            .Range(1, days)
            .Select(index => new Forecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ));
}
