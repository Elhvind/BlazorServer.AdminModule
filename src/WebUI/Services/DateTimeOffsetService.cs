using Shared.Application.Interfaces;

namespace WebUI.Services;

public class DateTimeOffsetService : IDateTimeOffset
{
    public DateTimeOffset Now => DateTimeOffset.Now;

    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
