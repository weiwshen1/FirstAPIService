﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();

            weatherForecasts.Add(new WeatherForecast {Date = DateTime.Now, TemperatureC = 20, Summary = "First TemperatureC" });
            weatherForecasts.Add(new WeatherForecast { Date = DateTime.Now, TemperatureC = 40, Summary = "Second TemperatureC" });
            weatherForecasts.Add(new WeatherForecast { Date = DateTime.Now, TemperatureC = 50, Summary = "Third TemperatureC" });
            return weatherForecasts.ToArray();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
