using Domain.Entities;
using MediatR;

namespace ApplicationCore.WeatherForecasts;

public class GetWeatherForecastListQueryResponse
{
    public List<WeatherForecast> Forecasts { get; set; } = new();
}

public record GetWeatherForecastListQuery : IRequest<GetWeatherForecastListQueryResponse>
{
    public DateTime StartDate { get; init; }
}

public class GetWeatherForecastListQueryHandler : IRequestHandler<GetWeatherForecastListQuery, GetWeatherForecastListQueryResponse>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<GetWeatherForecastListQueryResponse> Handle(GetWeatherForecastListQuery request, CancellationToken cancellationToken)
    {
        var forecasts = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = request.StartDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

        return Task.FromResult(new GetWeatherForecastListQueryResponse()
        {
            Forecasts = forecasts,
        });
    }
}
