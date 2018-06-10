using Mjknowles.Kata04.Part2.Models;
using Mjknowles.Kata04.Part2.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Mjknowles.Kata04.Part2.Tests.Services
{
    public class SeasonResultServiceTests
    {
        public readonly Mock<ILoggingService> _mockLoggingService;
        public readonly Mock<ISeasonResultProvider> _mockFileParser;
        private readonly List<ISeasonResult> _seasonResultData;

        public SeasonResultServiceTests()
        {
            _seasonResultData = new List<ISeasonResult>();

            _mockLoggingService = new Mock<ILoggingService>();
            _mockLoggingService.Setup(m => m.Log(It.IsAny<string>(), It.IsAny<Exception>()));

            _mockFileParser = new Mock<ISeasonResultProvider>();
            _mockFileParser.Setup(m => m.GetSeasonResults()).Returns(Task.FromResult((IEnumerable<ISeasonResult>)_seasonResultData));
        }

        [Fact]
        public async Task FindsMinimumGoalDifferentialAmongManyResults()
        {
            var result1 = new SeasonResult("abc", 2, 10);
            var result2 = new SeasonResult("def", 4, 7);
            var result3 = new SeasonResult("ghi", 11, 13);
            var result4 = new SeasonResult("jkl", 5, 6);


            _seasonResultData.AddRange(new SeasonResult[] { result1, result2, result3, result4 });

            var sut = new SeasonResultService(_mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetSeasonResultWithSmallestPointDifferential();

            Assert.Equal(result4.Team, result.Team);
        }

        [Fact]
        public async Task FindsMinimumGoalDifferentialSingleResult()
        {
            var result1 = new SeasonResult("abc", 2, 10);

            _seasonResultData.Add(result1);

            var sut = new SeasonResultService(_mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetSeasonResultWithSmallestPointDifferential();

            Assert.Equal(result1.Team, result.Team);
        }

        [Fact]
        public async Task UnableToFindMinimumTempSpreadWhenNoDays()
        {

            var sut = new SeasonResultService(_mockFileParser.Object, _mockLoggingService.Object);

            var result = await sut.GetSeasonResultWithSmallestPointDifferential();

            Assert.Equal(SeasonResult.EmptySeasonResult, result);
        }
    }
}
