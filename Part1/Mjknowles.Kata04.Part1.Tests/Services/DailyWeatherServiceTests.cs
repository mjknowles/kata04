using Mjknowles.Kata04.Part1.Models;
using Mjknowles.Kata04.Part1.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Mjknowles.Kata04.Part1.Tests.Services
{
    public class DailyWeatherServiceTests
    {
        public readonly Mock<ILoggingService> _mockLoggingService;
        public readonly Mock<IDailyWeatherFileParser> _mockFileParser;
        private readonly List<IDailyWeather> _weatherData;

        public DailyWeatherServiceTests()
        {
            _weatherData = new List<IDailyWeather>();

            _mockLoggingService = new Mock<ILoggingService>();
            _mockLoggingService.Setup(m => m.Log(It.IsAny<string>(), It.IsAny<Exception>()));

            _mockFileParser = new Mock<IDailyWeatherFileParser>();
            _mockFileParser.Setup(m => m.ParseDailyWeathers(It.IsAny<string>())).Returns(Task.FromResult((IEnumerable<IDailyWeather>)_weatherData));
        }

        [Fact]
        public async Task FindsMinimumTempSpreadAmongManyDays()
        {
            var weather1 = new DailyWeather(1, 2, 10);
            var weather2 = new DailyWeather(2, 4, 6);
            var weather3 = new DailyWeather(3, 11, 14);

            _weatherData.AddRange(new DailyWeather[] { weather1, weather2, weather3 });

            var sut = new DailyWeatherService(string.Empty,
                _mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetWeatherWithSmallestTempSpread();

            Assert.Equal(weather2.DayOfMonth, result.DayOfMonth);
        }

        [Fact]
        public async Task FindsMinimumTempSpreadSingleDay()
        {
            var weather1 = new DailyWeather(1, 2, 10);

            _weatherData.Add(weather1);

            var sut = new DailyWeatherService(string.Empty,
                _mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetWeatherWithSmallestTempSpread();

            Assert.Equal(weather1.DayOfMonth, result.DayOfMonth);
        }

        [Fact]
        public async Task UnableToFindMinimumTempSpreadWhenNoDays()
        {

            var sut = new DailyWeatherService(string.Empty,
                _mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetWeatherWithSmallestTempSpread();

            Assert.Equal(DailyWeather.EmptyDailyWeather, result);
        }
    }
}
