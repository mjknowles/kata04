using Mjknowles.Kata04.Part2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part2.Services
{
    public interface ISeasonResultService
    {
        Task<ISeasonResult> GetSeasonResultWithSmallestPointDifferential();
    }
}
