using System;
using System.Collections.Generic;
using System.Linq;

namespace HeavyArrayForecast;

public static class WeatherForecastHelper
{
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static IEnumerable<WeatherForecast> GetForecasts(int redundantIterations = 1000000)
    {
        IEnumerable<WeatherForecast> forecasts = null;
        Random rng = new();
        for (int i = 0; i < redundantIterations; i++)
        {
            // Calling ToList() realize it too early.
            forecasts = Enumerable.Range(1, 20).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }

        return forecasts;
    }
}