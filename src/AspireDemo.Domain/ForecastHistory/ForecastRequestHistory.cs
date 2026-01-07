namespace AspireDemo.Domain.ForecastHistory;

public sealed class ForecastRequestHistory
{
    public int Id { get; set; }

    public int DaysRequested { get; set; }

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
}
