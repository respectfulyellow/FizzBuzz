using System;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}