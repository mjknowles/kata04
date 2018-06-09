using Mjknowles.Kata04.Part1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part1.Services
{
    public interface IDailyWeatherFactory
    {
        bool TryCreate(string dayOfMonth, string minTemp, string maxTemp, out IDailyWeather dailyWeather);
        bool TryCreate(int dayOfMonth, int minTemp, int maxTemp, out IDailyWeather dailyWeather);
    }
}
