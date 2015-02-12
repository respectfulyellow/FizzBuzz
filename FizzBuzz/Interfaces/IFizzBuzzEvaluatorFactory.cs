using System.Collections.Generic;

namespace FizzBuzz.Interfaces
{
    public interface IFizzBuzzEvaluatorFactory
    {
        IFizzBuzzEvaluator Create(IList<Replacement> replacements);
    }
}