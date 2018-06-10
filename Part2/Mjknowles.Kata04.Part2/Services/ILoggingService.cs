using System;
using System.Collections.Generic;
using System.Text;

namespace Mjknowles.Kata04.Part2.Services
{
    public interface ILoggingService
    {
        void Log(string message, Exception ex = null);
    }
}
