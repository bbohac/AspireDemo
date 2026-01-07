using AspireDemo.Application.ForecastHistory;

namespace AspireDemo.Api.Api.ForecastHistory;

public static class ForecastHistoryEndpoints
{
    public static IEndpointRouteBuilder MapForecastHistoryEndpoints(this IEndpointRouteBuilder group)
    {
        group
            .MapGet(
                "/history",
                async (IForecastHistoryService forecastHistoryService) =>
                {
                    var entries = await forecastHistoryService.GetAllAsync();
                    return entries.Select(x => x.ToDto());
                }
            )
            .WithName("GetForecastHistory");

        return group;
    }
}
