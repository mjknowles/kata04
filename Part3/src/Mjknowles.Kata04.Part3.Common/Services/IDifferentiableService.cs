using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Common.Services
{
    public interface IDifferentiableService<T1, T2> where T1 : IDifferentiable<T2>
    {
        Task<T1> GetAbsoluteMinimumDifferentiable(T1 fallback);
    }
}
