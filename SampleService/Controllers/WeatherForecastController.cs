using Microsoft.AspNetCore.Mvc;
using SampleService.Services;
using System.Net.Http;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRootServiceClient _rootServiceClient;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRootServiceClient rootServiceClient)
        {
            _logger = logger;
            _rootServiceClient = rootServiceClient;
           
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<RootServiceNamespace.WeatherForecast>>> Get()
        {
           // _logger.LogInformation("WeatherForecastController >>> START  GetWeatherForecast");
            RootServiceNamespace.RootServiceClient rootServiceClient =
               new RootServiceNamespace.RootServiceClient("http://localhost:5227/", _httpClient);
            return Ok(await rootServiceClient.GetWeatherForecastAsync());
            //var res = await _rootServiceClient.Get();
           // _logger.LogInformation("WeatherForecastController >>> END  GetWeatherForecast");
            //return Ok(res);
        }
    }
}