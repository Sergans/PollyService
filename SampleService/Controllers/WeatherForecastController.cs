using Microsoft.AspNetCore.Mvc;
using SampleService.Services;
using System.Net.Http;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       // private IRootServiceClient _rootServiceClient;
        private readonly ILogger<WeatherForecastController> _logger;
        //private readonly HttpClient _httpClient;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
           
           
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
           // _logger.LogInformation("WeatherForecastController >>> START  GetWeatherForecast");
            RootServiceNamespace.RootServiceClient rootServiceClient =
               new RootServiceNamespace.RootServiceClient("http://localhost:5227/",new HttpClient());
            
            return Ok(rootServiceClient.GetWeatherForecastAsync().Result);
            //var res = await _rootServiceClient.Get();
           // _logger.LogInformation("WeatherForecastController >>> END  GetWeatherForecast");
            //return Ok(res);
        }
    }
}