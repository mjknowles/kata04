using Mjknowles.Kata04.Part3.Common.Models;
using Mjknowles.Kata04.Part3.Common.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mjknowles.Kata04.Part3.Common.Tests.Services
{
    public class IntDifferentiableFactoryTests
    {
        [Fact]
        public void ShouldTryCreateDifferentiable()
        {
            var fallbackDifferentiable = new Mock<IDifferentiable<int>>().Object;
            var createdDifferentiable = new Mock<IDifferentiable<int>>().Object;
            var mockSut = new Mock<IntDifferentiableFactory>(new Mock<ILoggingService>().Object);

            mockSut.Object.TryCreate("abc", "1", "2", fallbackDifferentiable, out createdDifferentiable);

            mockSut.Verify(m => m.TryCreate("abc", 1, 2, out createdDifferentiable), Times.Once);
        }

        [Fact]
        public void ShouldNotTryCreateDifferentiable()
        {
            var fallbackDifferentiable = new Mock<IDifferentiable<int>>().Object;
            var createdDifferentiable = new Mock<IDifferentiable<int>>().Object;
            var mockSut = new Mock<IntDifferentiableFactory>(new Mock<ILoggingService>().Object);

            mockSut.Object.TryCreate("abc", "def", "ghi", fallbackDifferentiable, out createdDifferentiable);

            Assert.Equal(fallbackDifferentiable, createdDifferentiable);
            mockSut.Verify(m => m.TryCreate("abc", It.IsAny<int>(), It.IsAny<int>(), out createdDifferentiable), Times.Never);
        }
    }
}
