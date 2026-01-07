using System.Text.Json;
using AspireDemo.Application.ForecastHistory;
using Microsoft.Extensions.Caching.Distributed;

namespace AspireDemo.Application.Forecast;

public sealed class ForecastCachingDecorator : IForecastService
{
    private readonly IForecastService _inner;
    private readonly IDistributedCache _cache;
    private readonly IForecastHistoryService _historyService;

    public ForecastCachingDecorator(
        IForecastService inner,
        IDistributedCache cache,
        IForecastHistoryService historyService
    )
    {
        _inner = inner;
        _cache = cache;
        _historyService = historyService;
    }

    public async Task<IEnumerable<Domain.Forecast.Forecast>> GetForecastAsync(int days)
    {
        var cacheKey = $"forecast:{days}";

        await _historyService.AddAsync(days);

        var cached = await _cache.GetStringAsync(cacheKey);
        if (cached is not null)
        {
            return JsonSerializer.Deserialize<IEnumerable<Domain.Forecast.Forecast>>(cached)!;
        }

        var result = await _inner.GetForecastAsync(days);

        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(result),
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) }
        );

        return result;
    }
}
