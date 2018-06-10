using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Football.Models
{
    public interface ISeasonResult : IDifferentiable<int>
    {
        string Team { get; }
    }
}
