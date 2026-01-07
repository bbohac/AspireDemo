using AspireDemo.Domain.Forecast;

namespace AspireDemo.Api.Api.Weather;

public static class ForecastMapping
{
    public static ForecastResponseDto ToDto(this Forecast forecast) =>
        new(forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
}
