using AspireDemo.Api.Domain.Forecasts;

namespace AspireDemo.Api.Application.Weather;

public interface IForecastService
{
    public IEnumerable<Forecast> GetForecast(int days);
}
