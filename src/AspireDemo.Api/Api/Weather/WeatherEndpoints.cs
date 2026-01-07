using AspireDemo.Api.Api.Filters;
using AspireDemo.Api.Application.Weather;
using AspireDemo.Application.ForecastHistory;
using FluentValidation;

namespace AspireDemo.Api.Api.Weather;

public static class WeatherEndpoints
{
    public static IEndpointRouteBuilder MapWeatherEndpoints(this IEndpointRouteBuilder group)
    {
        group
            .MapGet(
                "/forecast",
                async (
                    [AsParameters] ForecastRequestDto request,
                    IValidator<ForecastRequestDto> validator,
                    IForecastService forecastService,
                    IForecastHistoryService forcastHistoryService
                ) =>
                {
                    await forcastHistoryService.AddAsync(request.Days);

                    var forecast = forecastService.GetForecast(request.Days);
                    return Results.Ok(forecast.Select(x => x.ToDto()));
                }
            )
            .AddEndpointFilter<ValidationFilter<ForecastRequestDto>>()
            .WithName("GetWeatherForecast");

        return group;
    }
}
