namespace AspireDemo.Api.Api.Weather;

public sealed record ForecastResponseDto(DateOnly Date, int TemperatureC, int TemperatureF, string? Summary);
