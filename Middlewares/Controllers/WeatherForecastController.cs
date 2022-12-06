using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Middlewares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {

                throw new Exception();

            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}