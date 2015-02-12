using System.Collections.Generic;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    class FizzBuzzEvaluatorFactory : IFizzBuzzEvaluatorFactory
    {
        public IFizzBuzzEvaluator Create(IList<Replacement> replacements)
        {
            var fizzBuzzEvaluator = new FizzBuzzEvaluator(replacements);
            return fizzBuzzEvaluator;
        }
    }
}