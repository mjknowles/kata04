using Mjknowles.Kata04.Part3.Common;
using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Weather.Models;
using Mjknowles.Kata04.Part3.Weather.Services;
using System;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Weather
{
    class Program
    {
        private static ILoggingService _loggingService;
        private static IDifferentiableProvider<int> _dailyWeatherFileParser;

        public static async Task Main()
        {
            BuildDependencies();

            // For a real world application, we would want this file path configurable.
            // For now, this file is added to the project and copied to the output 
            // directory for simplicity._dailyWeatherFileParser

            var dailyWeatherService = new DailyWeatherService(_dailyWeatherFileParser, _loggingService);

            var programRunner = new ConsoleDifferentiableDisplayer<int>(dailyWeatherService);

            await programRunner.DisplayMinDifferential<IDailyTemperature>(
                (result) => $"Day number with minimum temperature spread: { result.DayOfMonth }",
                "Unable to determine day number with minimum temperature spread. See logs.",
                DailyTemperature.EmptyDailyWeather).ConfigureAwait(false);
        }

        private static void BuildDependencies()
        {
            // Wiring up dependencies manually for this simple application.
            // Could use DI framework if this were more complex.

            _loggingService = new LoggingService();
            var temperatureFactory = new DailyTemperatureFactory(_loggingService);
            _dailyWeatherFileParser = new DailyWeatherFileParser("weather.dat", temperatureFactory, _loggingService);
        }
    }
}
