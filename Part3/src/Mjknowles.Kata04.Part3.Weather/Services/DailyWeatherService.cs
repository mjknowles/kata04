using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Weather.Services
{
    /// <summary>
    /// Used to encapsulate logic associated with the collection of daily weather records.
    /// </summary>
    public class DailyWeatherService : IntDifferentiableService<IDailyWeather>, IDailyWeatherService
    {
        public DailyWeatherService(string dailyWeatherFilePath, IDailyWeatherFileParser fileParser, ILoggingService loggingService)
            :base(dailyWeatherFilePath, fileParser, loggingService)
        {
        }
    }
}
