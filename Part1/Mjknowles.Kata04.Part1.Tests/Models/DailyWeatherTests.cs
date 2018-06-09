using Mjknowles.Kata04.Part1.Models;
using System;
using Xunit;

namespace Mjknowles.Kata04.Part1.Tests.Models
{
    public class DailyWeatherTests
    {
        [Fact]
        public void DailyWeatherInitializedToInputParams()
        {
            var sut = new DailyWeather(1, 2, 3);
            Assert.Equal(1, sut.DayOfMonth);
            Assert.Equal(2, sut.MinTemp);
            Assert.Equal(3, sut.MaxTemp);
        }

        [Fact]
        public void CannotCreateDailyWeatherIfDayNumberInvalid()
        {
            Assert.Throws<ArgumentException>(() => new DailyWeather(-1, 1, 1));
        }
    }
}
