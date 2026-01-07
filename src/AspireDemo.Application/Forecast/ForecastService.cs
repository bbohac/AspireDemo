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

    public Task<IEnumerable<Domain.Forecast.Forecast>> GetForecastAsync(int days)
    {
        var start = DateOnly.FromDateTime(DateTime.UtcNow);

        var result = Enumerable
            .Range(1, days)
            .Select(index => new Domain.Forecast.Forecast(
                start.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ));

        return Task.FromResult(result);
    }
}
