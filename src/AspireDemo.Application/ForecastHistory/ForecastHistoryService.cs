using AspireDemo.Domain.ForecastHistory;
using AspireDemo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AspireDemo.Application.ForecastHistory;

public sealed class ForecastHistoryService : IForecastHistoryService
{
    private readonly AppDbContext _dbContext;

    public ForecastHistoryService(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(int daysRequested)
    {
        var entry = new ForecastRequestHistory { DaysRequested = daysRequested, RequestedAt = DateTime.UtcNow };

        _dbContext.ForecastRequestHistoryEntries.Add(entry);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ForecastRequestHistory>> GetAllAsync() =>
        await _dbContext.ForecastRequestHistoryEntries.OrderByDescending(x => x.RequestedAt).ToListAsync();
}
