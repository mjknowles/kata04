using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Weather.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Weather.Services
{
    public interface IDailyWeatherFactory : IDifferentiableFactory<IDailyWeather, int>
    {
    }
}
