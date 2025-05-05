using Microsoft.AspNetCore.Mvc;
using RedisDemo.API.Models;
using RedisDemo.API.Services;

namespace RedisDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<WeatherForecastController> _logger;
        private const string CacheKey = "weather_data";

        public WeatherForecastController(ICacheService cacheService, ILogger<WeatherForecastController> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var cached = await _cacheService.GetAsync<List<WeatherForecast>>(CacheKey);
            if (cached != null)
            {
                _logger.LogInformation("Cache hit.");
                return cached;
            }

            _logger.LogInformation("Cache miss. Generating new data...");
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Sunny"
            }).ToList();

            await _cacheService.SetAsync(CacheKey, result, TimeSpan.FromMinutes(1));
            return result;
        }

    }
}