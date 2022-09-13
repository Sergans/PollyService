using Microsoft.AspNetCore.Mvc;
using SampleService.Services;
using System.Net.Http;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private IRootServiceClient _rootServiceClient;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("RootServiceClient");

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            _logger.LogInformation("WeatherForecastController >>> START  GetWeatherForecast");
            RootServiceNamespace.RootServiceClient rootServiceClient =
              new RootServiceNamespace.RootServiceClient("http://localhost:5227/", _httpClient);
            var res = rootServiceClient.GetWeatherForecastAsync().Result;
            return Ok(res);
           // var res = await _rootServiceClient.Get();
           // _logger.LogInformation("WeatherForecastController >>> END  GetWeatherForecast");
           // return Ok(res);
        }
    }
}