using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Extensions;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class FizzBuzzEvaluator : IFizzBuzzEvaluator
    {
        private readonly IList<Replacement> _replacements;

        public FizzBuzzEvaluator(IList<Replacement> replacements)
        {
            _replacements = replacements;
        }

        public string Evaluate(int number)
        {
            var result = string.Join("",
                _replacements.Where(r => number.IsEvenlyDivisableBy(r.DivisibleBy))
                    .Select(r => r.ReplaceWith));

            return string.IsNullOrEmpty(result)
                ? number.ToString()
                : result;
        }
    }
}