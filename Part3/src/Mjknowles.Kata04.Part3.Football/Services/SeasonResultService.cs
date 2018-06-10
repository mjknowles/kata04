using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Football.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part3.Football.Services
{
    public class SeasonResultService : IntDifferentiableService
    {
        public SeasonResultService(IDifferentiableProvider<int> resultProvider, ILoggingService loggingService) 
            : base(resultProvider, loggingService)
        {
        }
    }
}
