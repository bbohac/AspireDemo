using AspireDemo.Domain.ForecastHistory;

namespace AspireDemo.Application.ForecastHistory;

public interface IForecastHistoryService
{
    public Task AddAsync(int daysRequested);

    public Task<IEnumerable<ForecastRequestHistory>> GetAllAsync();
}
