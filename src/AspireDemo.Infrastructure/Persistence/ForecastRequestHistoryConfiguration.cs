using AspireDemo.Domain.ForecastHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspireDemo.Infrastructure.Persistence;

internal sealed class ForecastRequestHistoryConfiguration : IEntityTypeConfiguration<ForecastRequestHistory>
{
    public void Configure(EntityTypeBuilder<ForecastRequestHistory> builder)
    {
        builder.Property(x => x.DaysRequested).IsRequired();
        builder.Property(x => x.RequestedAt).IsRequired();
    }
}
