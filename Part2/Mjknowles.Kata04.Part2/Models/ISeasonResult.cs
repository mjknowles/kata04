using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part2.Models
{
    public interface ISeasonResult
    {
        string Team { get; }
        int GoalsFor { get; }
        int GoalsAgainst { get; }
    }
}
