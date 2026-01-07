using AspireDemo.Domain.ForecastHistory;
using Microsoft.EntityFrameworkCore;

namespace AspireDemo.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public DbSet<ForecastRequestHistory> ForecastRequestHistoryEntries => Set<ForecastRequestHistory>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
