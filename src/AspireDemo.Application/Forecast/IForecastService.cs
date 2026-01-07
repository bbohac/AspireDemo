namespace AspireDemo.Application.Forecast;

public interface IForecastService
{
    public IEnumerable<Domain.Forecast.Forecast> GetForecast(int days);
}
