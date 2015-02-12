using FizzBuzz.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz.UnitTests
{
    [TestFixture]
    public class IntExtension_
    {
        [TestFixture]
        private class IsEvenlyDivisibleBy_Should_
        {
            [Test]
            public void Return_True_WhenNumberIsEvenlyDivisibleBySecondNumber()
            {
                4.IsEvenlyDivisableBy(2).Should().BeTrue();
            }

            [Test]
            public void Return_False_WhenNumberIsNotEvenlyDivisibleBySecondNumber()
            {
                5.IsEvenlyDivisableBy(2).Should().BeFalse();
            }
        }
    }
}