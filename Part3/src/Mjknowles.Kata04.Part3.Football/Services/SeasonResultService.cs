using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Football.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Football.Services
{
    public class SeasonResultService : IntDifferentiableService<ISeasonResult>, ISeasonResultService
    {
        public SeasonResultService(string filePath, ISeasonResultFileParser fileParser, ILoggingService loggingService) 
            : base(filePath, fileParser, loggingService)
        {
        }
    }
}
