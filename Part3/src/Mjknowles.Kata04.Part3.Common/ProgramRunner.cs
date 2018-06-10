using Mjknowles.Kata04.Part3.Common.Models;
using Mjknowles.Kata04.Part3.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Common
{
    public class ProgramRunner<T1, T2>
        where T1 : class, IDifferentiable<T2>
    {
        private readonly IDifferentiableService<T1, T2> _differentiableService;
        private readonly T1 _defaultResult;

        public ProgramRunner(IDifferentiableService<T1, T2> differentiableService,
            T1 defaultResult)
        {
            _differentiableService = differentiableService;
            _defaultResult = defaultResult;
        }

        public async Task DisplayMinDifferential(Func<T1, string> successMessage, string failureMessage)
        {
            // For a real world application, we would want this file path configurable.
            // For now, this file is added to the project and copied to the output 
            // directory for simplicity.

            var minDifferential = await _differentiableService.GetAbsoluteMinimumDifferentiable(_defaultResult).ConfigureAwait(false);

            if (minDifferential != _defaultResult)
            {
                Console.Out.WriteLine(successMessage(minDifferential));
            }
            else
            {
                Console.Out.WriteLine(failureMessage);
            }
            Console.In.ReadLine();
        }
    }
}
