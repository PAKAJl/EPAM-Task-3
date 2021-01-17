using System;
using Task3.Logger.Interfaces;

namespace Task3.Logger
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
