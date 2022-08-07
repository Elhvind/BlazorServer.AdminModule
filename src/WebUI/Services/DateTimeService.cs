using SharedKernel.Interfaces;

namespace WebUI.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}
