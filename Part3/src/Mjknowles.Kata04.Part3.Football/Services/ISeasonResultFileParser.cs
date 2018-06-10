using Mjknowles.Kata04.Part3.Common.Services;
using Mjknowles.Kata04.Part3.Football.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Football.Services
{
    public interface ISeasonResultFileParser : IFileParser<ISeasonResult>
    {
        Task<IEnumerable<ISeasonResult>> ParseFile(string filePath);
    }
}
