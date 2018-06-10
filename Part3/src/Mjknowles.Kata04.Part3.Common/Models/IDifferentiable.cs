using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Common.Models
{
    public interface IDifferentiable<T>
    {
        T Difference { get; }
        T AbsoluteDifference { get; }
    }
}
