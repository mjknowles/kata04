using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mjknowles.Kata04.Part3.Common.Services
{
    public interface IFileParser<T>
    {
        Task<IEnumerable<T>> ParseFile(string filePath);
    }
}
