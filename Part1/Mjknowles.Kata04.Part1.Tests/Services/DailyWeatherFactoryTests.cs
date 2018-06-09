using Mjknowles.Kata04.Part1.Models;
using Mjknowles.Kata04.Part1.Services;
using Moq;
using System;
using Xunit;

namespace Mjknowles.Kata04.Part1.Tests.Services
{
    public class DailyWeatherFactoryTests
    {
        public Mock<ILoggingService> _mockLoggingService;

        public DailyWeatherFactoryTests()
        {
            _mockLoggingService = new Mock<ILoggingService>();
            _mockLoggingService.Setup(m => m.Log(It.IsAny<string>(), It.IsAny<Exception>()));
        }

        [Fact]
        public void CreatesDailyWeatherFromValidStringParams()
        {
            IDailyWeather result;
            var sut = new DailyWeatherFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("1", "2", "3", out result);

            Assert.True(success);
            Assert.Equal(1, result.DayOfMonth);
            Assert.Equal(2, result.MinTemp);
            Assert.Equal(3, result.MaxTemp);
        }

        [Fact]
        public void CreatesDailyWeatherFromValidIntParams()
        {
            IDailyWeather result;
            var sut = new DailyWeatherFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate(1, 2, 3, out result);

            Assert.True(success);
            Assert.Equal(1, result.DayOfMonth);
            Assert.Equal(2, result.MinTemp);
            Assert.Equal(3, result.MaxTemp);
        }

        [Fact]
        public void CreatesEmptyDailyWeatherFromInvalidStringParams()
        {
            IDailyWeather result;
            var sut = new DailyWeatherFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("a", "b", "c", out result);

            Assert.False(success);
            Assert.Equal(DailyWeather.EmptyDailyWeather, result);
        }

        [Fact]
        public void CreatesEmptyDailyWeatherFromInvalidIntParams()
        {
            IDailyWeather result;
            var sut = new DailyWeatherFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate(-1, 2, 3, out result);

            Assert.False(success);
            Assert.Equal(DailyWeather.EmptyDailyWeather, result);
        }
    }
}
