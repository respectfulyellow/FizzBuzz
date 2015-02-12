using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.UnitTests
{
    [TestFixture]
    public class FizzBuzzEvaluator_
    {
        [TestFixture]
        public class Evaluate_Should_
        {
            [Test]
            public void Return_NumberWhenOne()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(1);

                result.Should().Be("1");
            }

            [Test]
            public void Return_2When2()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(2);
                result.Should().Be("2");
            }

            [Test]
            public void Return_FizzWhen3()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(3);
                result.Should().Be("Fizz");
            }

            [Test]
            public void Return_BuzzWhen5()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(5);
                result.Should().Be("Buzz");
            }

            [Test]
            public void Return_FizzWhenMultipleOf3()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(6);
                result.Should().Be("Fizz");
            }

            [Test]
            public void Return_BuzzWhenMultipleOf5()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(10);
                result.Should().Be("Buzz");
            }

            [Test]
            public void Return_FizzBuzzEvaluator_When_MultipleOf3And5()
            {
                var fizzBuzzEvaluator = CreateDefaultFizzBuzzEvaluator();
                var result = fizzBuzzEvaluator.Evaluate(15);
                result.Should().Be("FizzBuzz");
            }

            [Test]
            public void Use_Replacement_When_OneReplacementPassedIn()
            {
                var replacements = new List<Replacement>
                {
                    new Replacement(2, "GoodMorning")
                };
                var fizzBuzzEvaluator = new FizzBuzzEvaluator(replacements);
                var result = fizzBuzzEvaluator.Evaluate(2);
                result.Should().Be("GoodMorning");
            }

            [Test]
            public void Use_Replacement_When_MultipleReplacementsPassedIn()
            {
                var replacements = new List<Replacement>
                {
                    new Replacement(2, "GoodMorning"),
                    new Replacement(3, "Eric"),
                    new Replacement(5, "HowAreYou")
                };
                var fizzBuzzEvaluator = new FizzBuzzEvaluator(replacements);
                var result = fizzBuzzEvaluator.Evaluate(30);
                result.Should().Be("GoodMorningEricHowAreYou");
            }

            private static FizzBuzzEvaluator CreateDefaultFizzBuzzEvaluator()
            {
                var replacements = new List<Replacement>
                {
                    new Replacement(3, "Fizz"),
                    new Replacement(5, "Buzz")
                };

                var fizzBuzzEvaluator = new FizzBuzzEvaluator(replacements);
                return fizzBuzzEvaluator;
            }

        }
    }
}