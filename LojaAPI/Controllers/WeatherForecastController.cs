using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new List<string>
        {
            "Freezing"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var listaForecast = Enumerable.Range(0, 5).Select(index => new WeatherForecast
            
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(5, 35),
                Summary = Summaries[Random.Shared.Next(Summaries.Count)]
            })
            .ToArray();
            return listaForecast;
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public void Post([FromBody] string summary, double temperatura, bool precisaDeBlusa)
        {
             Summaries.Add(summary);
        }
    }
}