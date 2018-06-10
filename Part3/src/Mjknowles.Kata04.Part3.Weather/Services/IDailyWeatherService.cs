using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Weather.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Weather.Services
{
    public interface IDailyWeatherService : IDifferentiableService<IDailyWeather, int>
    {
    }
}
