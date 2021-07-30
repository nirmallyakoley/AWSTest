using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoGamingAPI.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContosoGamingAPI.Controllers
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
            string[] nodeArr = { "AB3", "BC9", "CD3", "DE6", "AD4", "DA5", "CE2", "AE4", "EB1" };
            LandMarkOperation objLandMarkOperation = new LandMarkOperation();
            foreach (string element in nodeArr)
            {
                objLandMarkOperation.CreateLandmarkNode(element);
            }
            int distance =objLandMarkOperation.CalculateDistance("A-B-C");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
