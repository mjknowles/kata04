using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Common.Services
{
    public interface IDifferentiableFactory<T1, T2> where T1 : IDifferentiable<T2>
    {
        bool TryCreate(string id, T2 value1, T2 value2, out T1 differentiable);
        bool TryCreate(string id, string value1, string value2, T1 fallback, out T1 differentiable);
    }
}
