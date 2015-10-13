using System.Threading.Tasks;
using WeatherAndroidXamarin.Models;

namespace WeatherAndroidXamarin.Service.Weather
{
    interface IWeatherService
    {
        Task<Forecast> GetForecastForToday(string city);
        Task<Forecast> GetForecastForTomorrow(string city);
        Task<Forecast> GetForecastForTheDayAfterTomorrow(string city);
        Task<Forecast> GetForecastForTheDayAfterAfterTomorrow(string city);
    }
}