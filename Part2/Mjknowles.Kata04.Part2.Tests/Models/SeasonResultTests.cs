using Mjknowles.Kata04.Part2.Models;
using System;
using Xunit;

namespace Mjknowles.Kata04.Part2.Tests.Models
{
    public class SeasonResultTests
    {
        [Fact]
        public void SeasonResultInitializedToInputParams()
        {
            var sut = new SeasonResult("abc", 2, 3);
            Assert.Equal("abc", sut.Team);
            Assert.Equal(2, sut.GoalsFor);
            Assert.Equal(3, sut.GoalsAgainst);
        }

        [Fact]
        public void CannotCreateSeasonResultIfGoalsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new SeasonResult("abc", -1, 1));
            Assert.Throws<ArgumentException>(() => new SeasonResult("abc", 1, -1));
        }
    }
}
