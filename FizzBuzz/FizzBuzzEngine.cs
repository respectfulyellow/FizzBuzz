using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Extensions;
using FizzBuzz.Interfaces;

namespace FizzBuzz
{
    public class FizzBuzzEngine
    {
        private readonly IFizzBuzzEvaluatorFactory _fizzBuzzEvaluatorFactory;
        private readonly IOutput _output;
        private readonly IFizzBuzzDefaultReplacements _fizzBuzzDefaultReplacements;

        public FizzBuzzEngine() : 
            this(new FizzBuzzEvaluatorFactory(), 
            new ConsoleOutput(),
            new FizzBuzzDefaultReplacements())
        {
        }

        public FizzBuzzEngine(IFizzBuzzEvaluatorFactory fizzBuzzEvaluatorFactory,
            IOutput output, 
            IFizzBuzzDefaultReplacements fizzBuzzDefaultReplacements)
        {
            _fizzBuzzEvaluatorFactory = fizzBuzzEvaluatorFactory;
            _output = output;
            _fizzBuzzDefaultReplacements = fizzBuzzDefaultReplacements;
        }

        public void Run(int numberOfIterations = 100, 
            IList<Replacement> replacements = null)
        {
            replacements = replacements ?? _fizzBuzzDefaultReplacements.Default;
            var fizzBuzzEvaluator = _fizzBuzzEvaluatorFactory.Create(replacements);

            for (var loop = 1; loop <= numberOfIterations; loop++)
            {
                _output.WriteLine(fizzBuzzEvaluator.Evaluate(loop));
            }
        }

    }
}