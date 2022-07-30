using Application.Common.Interfaces;

namespace Infrastructure.Services;

public class DateTimeOffsetService : IDateTimeOffset
{
    public DateTimeOffset Now => DateTimeOffset.Now;

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
