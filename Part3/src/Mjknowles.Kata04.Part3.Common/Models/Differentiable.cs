using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Common.Models
{
    public abstract class IntDifferentiable : IDifferentiable<int>
    {
        public IntDifferentiable(int value1, int value2)
        {
            Difference = value1 - value2;
            AbsoluteDifference = Math.Abs(value1 - value2);
        }

        public int Difference { get; }

        public int AbsoluteDifference { get; }
    }
}
