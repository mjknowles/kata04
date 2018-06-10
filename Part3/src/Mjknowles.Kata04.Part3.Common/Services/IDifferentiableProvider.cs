using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Common.Services
{
    public interface IDifferentiableProvider<T>
    {
        Task<IEnumerable<IDifferentiable<T>>> GetDifferentiables();
    }
}
