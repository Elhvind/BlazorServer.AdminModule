namespace Shared.Domain.UnitTests.BaseDomainEventTests;

public class BaseDomainEvent_Constructor
{
    public class TestEvent : BaseDomainEvent
    { }

    [Fact]
    public void SetsTimeToCurrentTime()
    {
        var newEvent = new TestEvent();

        newEvent.DateOccurred.Should().BeCloseTo(DateTime.UtcNow, new TimeSpan(100));
    }
}
