using AspireDemo.Domain.ForecastHistory;

namespace AspireDemo.Api.Api.ForecastHistory;

public static class ForecastHistoryMapping
{
    public static ForecastHistoryResponseDto ToDto(this ForecastRequestHistory model) =>
        new(model.Id, model.DaysRequested, model.RequestedAt);
}
