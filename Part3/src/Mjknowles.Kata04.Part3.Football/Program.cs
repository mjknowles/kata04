using Mjknowles.Kata04.Part3.Common;
using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Football.Models;
using Mjknowles.Kata04.Part3.Football.Services;
using System;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Football
{
    public static class Program
    {
        private static ILoggingService _loggingService;
        private static ISeasonResultFileParser _seasonResultFileParser;

        public static async Task Main()
        {
            BuildDependencies();

            // For a real world application, we would want this file path configurable.
            // For now, this file is added to the project and copied to the output 
            // directory for simplicity.

            var seasonResultService = new SeasonResultService("football.dat", _seasonResultFileParser, _loggingService);

            var programRunner = new ProgramRunner<ISeasonResult, int>(seasonResultService, SeasonResult.EmptySeasonResult);

            await programRunner.DisplayMinDifferential(
                (result) => $"Team with smallest point differential: { result.Team }",
                "Unable to determine team with smallest point differential. See logs.");
        }

        private static void BuildDependencies()
        {
            // Wiring up dependencies manually for this simple application.
            // Could use DI framework if this were more complex.

            _loggingService = new LoggingService();
            var seasonResultFactory = new SeasonResultFactory(_loggingService);
            _seasonResultFileParser = new SeasonResultFileParser(seasonResultFactory, _loggingService);
        }
    }
}
