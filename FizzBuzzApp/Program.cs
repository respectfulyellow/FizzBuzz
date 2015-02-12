using System;
using System.Collections.Generic;
using FizzBuzz;

namespace FizzBuzzApp
{
    class Program
    {
        static void Main()
        {
            var replacements = new List<Replacement>
            {
                new Replacement(2, "Fizzer"),
                new Replacement(4, "Buzzer"),
                new Replacement(5, "Lozzur")
            };
            var fizzBuzzEngine = new FizzBuzzEngine();

            fizzBuzzEngine.Run();
            Console.WriteLine("-----");
            fizzBuzzEngine.Run(10, replacements);
        }
    }
}
