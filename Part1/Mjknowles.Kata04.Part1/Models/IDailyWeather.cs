using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part1.Models
{
    public interface IDailyWeather
    {
        int DayOfMonth { get; }
        int MaxTemp { get; }
        int MinTemp { get; }
    }
}
