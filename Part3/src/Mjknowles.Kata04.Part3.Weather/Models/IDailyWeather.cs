using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Weather.Models
{
    public interface IDailyWeather : IDifferentiable<int>
    {
        int DayOfMonth { get; }
    }
}
