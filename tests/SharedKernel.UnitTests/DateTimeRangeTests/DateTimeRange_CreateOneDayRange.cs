namespace Shared.Domain.UnitTests.DateTimeRangeTests;

public class DateTimeRange_CreateOneDayRange
{
    [Fact]
    public void CreatesRangeWithStartDateLastingOneDay()
    {
        var dtr = DateTimeRange.CreateOneDayRange(DateTimes.TestDateTime);

        dtr.Start.Should().Be(DateTimes.TestDateTime);
        dtr.End.Should().Be(dtr.Start.AddDays(1));
    }
}
