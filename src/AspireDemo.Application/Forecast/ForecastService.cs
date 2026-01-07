namespace AspireDemo.Application.Forecast;

public sealed class ForecastService : IForecastService
{
    private static readonly string[] Summaries =
    [
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
    ];

    public IEnumerable<Domain.Forecast.Forecast> GetForecast(int days) =>
        Enumerable
            .Range(1, days)
            .Select(index => new Domain.Forecast.Forecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ));
}
