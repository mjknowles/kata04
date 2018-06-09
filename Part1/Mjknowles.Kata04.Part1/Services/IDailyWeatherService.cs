using Mjknowles.Kata04.Part1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part1.Services
{
    public interface IDailyWeatherService
    {
        Task<IDailyWeather> GetWeatherWithSmallestTempSpread();
    }
}
