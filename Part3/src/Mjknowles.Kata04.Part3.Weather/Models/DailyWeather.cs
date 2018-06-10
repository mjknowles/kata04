using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Weather.Models
{
    /// <summary>
    /// Represents a record of a day's weather data
    /// </summary>
    public class DailyWeather : IntDifferentiable, IDailyWeather
    {
        public static DailyWeather EmptyDailyWeather = new DailyWeather();

        public int DayOfMonth { get; }

        public DailyWeather(int dayOfMonth, int minTemp, int maxTemp) : base(minTemp, maxTemp)
        {
            if (dayOfMonth < 1 || dayOfMonth > 31) throw new ArgumentException("Day of month must be greater than 1 and less than 31");
            if (maxTemp < minTemp) throw new ArgumentException("Max temp must be lower than min temp.");

            DayOfMonth = dayOfMonth;
        }

        // Private constructor used for empty object

        private DailyWeather() : base(0, 0) { }

        // Equality operations overridden for completeness. The intent is that
        // this application treats IntDifferentiable as a value object.

        public override bool Equals(Object obj)
        {
            return obj is DailyWeather dailyWeather && this == dailyWeather;
        }

        public override int GetHashCode()
        {
            return DayOfMonth.GetHashCode() ^ Difference.GetHashCode();
        }

        public static bool operator ==(DailyWeather x, DailyWeather y)
        {
            return x.DayOfMonth == y.DayOfMonth && x.Difference == y.Difference;
        }

        public static bool operator !=(DailyWeather x, DailyWeather y)
        {
            return !(x == y);
        }
    }
}
