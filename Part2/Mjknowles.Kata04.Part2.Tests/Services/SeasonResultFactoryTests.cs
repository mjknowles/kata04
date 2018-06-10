using Mjknowles.Kata04.Part2.Models;
using Mjknowles.Kata04.Part2.Services;
using Moq;
using System;
using Xunit;

namespace Mjknowles.Kata04.Part2.Tests.Services
{
    public class SeasonResultFactoryTests
    {
        public Mock<ILoggingService> _mockLoggingService;

        public SeasonResultFactoryTests()
        {
            _mockLoggingService = new Mock<ILoggingService>();
            _mockLoggingService.Setup(m => m.Log(It.IsAny<string>(), It.IsAny<Exception>()));
        }

        [Fact]
        public void CreatesSeasonResultFromValidStringParams()
        {
            ISeasonResult result;
            var sut = new SeasonResultFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("abc", "2", "3", out result);

            Assert.True(success);
            Assert.Equal("abc", result.Team);
            Assert.Equal(2, result.GoalsFor);
            Assert.Equal(3, result.GoalsAgainst);
        }

        [Fact]
        public void CreatesSeasonResultFromValidIntParams()
        {
            ISeasonResult result;
            var sut = new SeasonResultFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("abc", 2, 3, out result);

            Assert.True(success);
            Assert.Equal("abc", result.Team);
            Assert.Equal(2, result.GoalsFor);
            Assert.Equal(3, result.GoalsAgainst);
        }

        [Fact]
        public void CreatesEmptySeasonResultFromInvalidStringParams()
        {
            ISeasonResult result;
            var sut = new SeasonResultFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("a", "b", "c", out result);

            Assert.False(success);
            Assert.Equal(SeasonResult.EmptySeasonResult, result);
        }

        [Fact]
        public void CreatesEmptySeasonResultFromInvalidIntParams()
        {
            ISeasonResult result;
            var sut = new SeasonResultFactory(_mockLoggingService.Object);

            bool success = sut.TryCreate("abc", -1, 3, out result);

            Assert.False(success);
            Assert.Equal(SeasonResult.EmptySeasonResult, result);
        }
    }
}
