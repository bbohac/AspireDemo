namespace AspireDemo.Application.Forecast;

public interface IForecastService
{
    public Task<IEnumerable<Domain.Forecast.Forecast>> GetForecastAsync(int days);
}
