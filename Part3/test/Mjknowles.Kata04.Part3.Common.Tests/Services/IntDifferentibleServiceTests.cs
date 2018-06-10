using Mjknowles.Kata04.Part3.Common.Models;
using Mjknowles.Kata04.Part3.Common.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mjknowles.Kata04.Part3.Common.Tests.Services
{
    public class IntDifferentibleServiceTests
    {
        private IEnumerable<IDifferentiable<int>> _differentiables;

        public IntDifferentibleServiceTests()
        {
            _differentiables = new List<IDifferentiable<int>>();
        }

        [Fact]
        public async Task ShouldGetMinimumDifferentiable()
        {
            var provider = new Mock<IDifferentiableProvider<int>>();
            var loggingService = new Mock<ILoggingService>();
            var fallback = new Mock<IntDifferentiable>(2, 3).Object;

            var mockDiff1 = new Mock<IntDifferentiable>(1, 4).Object;
            var mockDiff2 = new Mock<IntDifferentiable>(5, 7).Object;
            var mockDiff3 = new Mock<IntDifferentiable>(10, 20).Object;

            _differentiables = new IntDifferentiable[] { mockDiff1, mockDiff2, mockDiff3 };
            provider.Setup(p => p.GetDifferentiables()).Returns(Task.FromResult(_differentiables));

            var sut = new Mock<IntDifferentiableService>(provider.Object, loggingService.Object).Object;

            var result = await sut.GetAbsoluteMinimumDifferentiable(fallback).ConfigureAwait(false);

            Assert.Equal(mockDiff2, result);
        }
    }
}
