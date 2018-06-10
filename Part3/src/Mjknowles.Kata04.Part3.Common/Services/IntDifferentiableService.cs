using Mjknowles.Kata04.Part3.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Common.Services
{
    public abstract class IntDifferentiableService<T> : IDifferentiableService<T, int> where T : IDifferentiable<int>
    {
        protected readonly ILoggingService _loggingService;
        protected readonly IFileParser<T> _fileParser;
        protected IEnumerable<T> _differentiables;
        private string _filePath;

        public IntDifferentiableService(string filePath, IFileParser<T> fileParser, ILoggingService loggingService)
        {
            _filePath = filePath;
            _fileParser = fileParser;
            _loggingService = loggingService;
        }

        public async Task<T> GetAbsoluteMinimumDifferentiable(T fallback)
        {
            // If this application were any larger/complex, we would need to abstract out this initialization
            // of the _differentiables collection. If we were to add more methods to this class, we would
            // have to make this check in each new method that used the collection which would not be good.

            if (_differentiables == null) _differentiables = await GetDifferentiables().ConfigureAwait(false);

            // Determine the smallest differential in the list.
            // Assumes that it's acceptable to return the first one in the
            // list if two or more days have the same difference.

            return _differentiables.Any() ? _differentiables.Aggregate((d1, d2) =>
                d1.AbsoluteDifference < d2.AbsoluteDifference ? d1 : d2) : fallback;
        }

        protected virtual async Task<IEnumerable<T>> GetDifferentiables()
        {
            try
            {
                return await _fileParser.ParseFile(_filePath).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _loggingService.Log("Unable to retrieve season result data.", ex);
                return Enumerable.Empty<T>();
            }
        }
    }
}
