using Mjknowles.Kata04.Part3.Common.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mjknowles.Kata04.Part3.Common.Tests.Models
{
    public class IntDifferentiableTests
    {
        [Fact]
        public void ShouldCreateDifferentiableWithCorrectValue()
        {
            var diff = new Mock<IntDifferentiable>(2, 5).Object;
            Assert.Equal(3, diff.AbsoluteDifference);

            diff = new Mock<IntDifferentiable>(8, 6).Object;
            Assert.Equal(2, diff.AbsoluteDifference);

            diff = new Mock<IntDifferentiable>(-2, 10).Object;
            Assert.Equal(12, diff.AbsoluteDifference);

            diff = new Mock<IntDifferentiable>(12, -4).Object;
            Assert.Equal(16, diff.AbsoluteDifference);
        }
    }
}
