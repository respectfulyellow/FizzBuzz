using System.Collections.Generic;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class FizzBuzzDefaultReplacements : IFizzBuzzDefaultReplacements
    {
        private readonly List<Replacement> _replacements;

        public FizzBuzzDefaultReplacements()
        {
            _replacements = new List<Replacement>
                {
                    new Replacement(3, "Fizz"),
                    new Replacement(5, "Buzz")
                };
        }

        public IList<Replacement> Default
        {
            get
            {
                return _replacements;
            }
        }
    }
}
