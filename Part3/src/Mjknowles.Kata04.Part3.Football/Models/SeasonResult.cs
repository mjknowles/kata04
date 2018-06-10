using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Football.Models
{
    /// <summary>
    /// Represents a record of a team's EPL season result
    /// </summary>
    public class SeasonResult : IntDifferentiable, ISeasonResult
    {
        public static SeasonResult EmptySeasonResult = new SeasonResult();
        
        public string Team { get; }

        public SeasonResult(string team, int goalsFor, int goalsAgainst) : base(goalsFor, goalsAgainst)
        {
            if (goalsFor < 0 || goalsAgainst < 0) throw new ArgumentException("Goals for and against must be 0 or greater.");
            Team = team;
        }

        // Private constructor used for empty object

        private SeasonResult() : base(0, 0) { Team = String.Empty; }

        // Equality operations overridden for completeness. The intent is that
        // this application treats IntDifferentiable as a value object.

        public override bool Equals(Object obj)
        {
            return obj is SeasonResult seasonResult && this == seasonResult;
        }

        public override int GetHashCode()
        {
            return Team.GetHashCode() ^ Difference.GetHashCode();
        }

        public static bool operator ==(SeasonResult x, SeasonResult y)
        {
            return x.Team == y.Team && x.Difference == y.Difference;
        }

        public static bool operator !=(SeasonResult x, SeasonResult y)
        {
            return !(x == y);
        }
    }
}
