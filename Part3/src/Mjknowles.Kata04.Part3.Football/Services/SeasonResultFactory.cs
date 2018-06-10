using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Football.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Football.Services
{
    /// <summary>
    /// Encapsulates the logic needed to create a SeasonResult object.
    /// </summary>
    public class SeasonResultFactory : IntDifferentiableFactory<ISeasonResult>, ISeasonResultFactory
    {
        public SeasonResultFactory(ILoggingService loggingService) : base(loggingService)
        {
        }

        /// <summary>
        /// Creates a SeasonResult object.
        /// </summary>
        /// <returns>True if object successfully created with input params. False if not and out param is set to empty object.</returns>
        public override bool TryCreate(string team, int goalsFor, int goalsAgainst, out ISeasonResult seasonResult)
        {
            try
            {
                seasonResult = new SeasonResult(team, goalsFor, goalsAgainst);
            }
            catch(Exception ex)
            {
                _loggingService.Log("Unable to create SeasonResult object from numeric values.", ex);
                seasonResult = SeasonResult.EmptySeasonResult;
            }

            return (SeasonResult)seasonResult != SeasonResult.EmptySeasonResult;
        }
    }
}
