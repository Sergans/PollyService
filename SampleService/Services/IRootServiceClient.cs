namespace SampleService.Services
{
    public interface IRootServiceClient
    {
        RootServiceNamespace.RootServiceClient Client { get; }
        public Task<ICollection<RootServiceNamespace.WeatherForecast>> Get();
    }
}
