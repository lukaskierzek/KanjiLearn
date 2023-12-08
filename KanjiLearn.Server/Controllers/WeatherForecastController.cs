using Microsoft.AspNetCore.Mvc;

namespace KanjiLearn.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly IWeatherForecastService _forecastService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService, IConfiguration configuration)
        {
            _logger = logger;
            _forecastService = weatherForecastService;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _forecastService.Get(8, -11, 33);
            return result;
        }

        [HttpGet("CurrentDay/{max}")]
        public IEnumerable<WeatherForecast> Get2([FromRoute] int max, [FromQuery] int take)
        {
            var result = _forecastService.Get();
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody]string name)
        {

            //return StatusCode(401, $"Hello {name}!");

            return NotFound($"Hello {name}!");
        }

        [HttpPost("Generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int numberOfResult, [FromBody] TemperatureRequestDTO temperatureRequestDTO)
        {
            var connString = _configuration.GetConnectionString("KanjiLearnDatabase");

            TemperatureRequest temperatureRequest = new()
            {
                min = temperatureRequestDTO.min,
                max = temperatureRequestDTO.max,
            };

            if (numberOfResult <= 0 || temperatureRequest.min > temperatureRequest.max || (temperatureRequest.min < 0 && temperatureRequest.max < 0))
                return BadRequest();

            var result = _forecastService.Get(numberOfResult, temperatureRequest.min, temperatureRequest.max);
            return Ok(result);
        }

      
    }
}
