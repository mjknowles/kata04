using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Weather.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Weather.Services
{
    /// <summary>
    /// Encapsulates the logic needed to create a Daily Weather object.
    /// </summary>
    public class DailyWeatherFactory : IntDifferentiableFactory<IDailyWeather>, IDailyWeatherFactory
    {
        public DailyWeatherFactory(ILoggingService loggingService) : base(loggingService)
        {
        }

        /// <summary>
        /// Creates a DailyWeather object.
        /// </summary>
        /// <returns>True if object successfully created with input params. False if not and out param is set to empty object.</returns>
        public override bool TryCreate(string dayOfMonth, int minTemp, int maxTemp, out IDailyWeather dailyWeather)
        {
            try
            {
                int numDayOfMonth;
                var successful = int.TryParse(dayOfMonth, out numDayOfMonth);
                dailyWeather = successful ? new DailyWeather(numDayOfMonth, minTemp, maxTemp) : DailyWeather.EmptyDailyWeather;
            }
            catch(Exception ex)
            {
                _loggingService.Log("Unable to create DailyWeather object from numeric values.", ex);
                dailyWeather = DailyWeather.EmptyDailyWeather;
            }

            return (DailyWeather)dailyWeather != DailyWeather.EmptyDailyWeather;
        }
    }
}
