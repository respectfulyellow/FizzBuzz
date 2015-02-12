using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Interfaces;
using NUnit.Framework;
using Telerik.JustMock;

namespace FizzBuzz.UnitTests
{
    [TestFixture]
    public class FizzBuzzEngine_
    {
        [TestFixture]
        public class Run_Should_
        {
            private IFizzBuzzEvaluatorFactory _fizzBuzzEvaluatorFactory;
            private IOutput _output;
            private IFizzBuzzEvaluator _fizzBuzzEvaluator;
            private IFizzBuzzDefaultReplacements _fizzBuzzDefaultReplacements;

            [SetUp]
            public void SetUp()
            {
                _fizzBuzzEvaluatorFactory = Mock.Create<IFizzBuzzEvaluatorFactory>();
                _fizzBuzzEvaluator = Mock.Create<IFizzBuzzEvaluator>();
                _fizzBuzzDefaultReplacements = Mock.Create<IFizzBuzzDefaultReplacements>();

                _output = Mock.Create<IOutput>();
            }

            [Test]
            public void Call_FizzBuzzEvaluatorFactory()
            {
                var fizzBuzzEvaluator = Mock.Create<IFizzBuzzEvaluator>();
                Mock.Arrange(() => _fizzBuzzEvaluatorFactory.Create(Arg.IsAny<IList<Replacement>>()))
                    .Returns(fizzBuzzEvaluator).MustBeCalled();

                var fizzBuzzEngine = CreateFizzBuzzEngine();

                fizzBuzzEngine.Run();

                Mock.Assert(_fizzBuzzEvaluatorFactory);
            }

            [Test]
            public void Call_FizzBuzzEvaluateTheInputNumberOfTimes()
            {
                const int iterations = 10;
                var fizzBuzzEvaluator = CreateFizzBuzzEvaluator();
                Mock.Arrange(() => fizzBuzzEvaluator.Evaluate(Arg.AnyInt))
                    .Occurs(iterations);
                var fizzBuzzEngine = CreateFizzBuzzEngine();
                
                fizzBuzzEngine.Run(iterations);

                Mock.Assert(_fizzBuzzEvaluator);
            }

            [Test]
            public void Call_OutputOnceForEachInput()
            {
                var fizzBuzzEvaluator = CreateFizzBuzzEvaluator();
                Mock.Arrange(() => fizzBuzzEvaluator.Evaluate(Arg.AnyInt))
                    .Returns((int i) => i.ToString());

                Mock.Arrange(() => _output.WriteLine("1")).OccursOnce();
                Mock.Arrange(() => _output.WriteLine("2")).OccursOnce();

                var fizzBuzzEngine = CreateFizzBuzzEngine();
                
                fizzBuzzEngine.Run(2);
                
                Mock.Assert(_output);
            }

            [Test]
            public void _Use_DefaultReplacements_WhenInputReplacementsIsNull()
            {
                var replacement = new Replacement(2, "Hello");
                IList<Replacement> replacements = new List<Replacement>
                    {replacement};
                Mock.Arrange(() => _fizzBuzzDefaultReplacements.Default)
                    .Returns(replacements).MustBeCalled();

                Mock.Arrange(() => _fizzBuzzEvaluatorFactory
                    .Create(Arg.Matches<IList<Replacement>>(i => i.Count == 1 && Equals(i.First(), replacement))))
                    .Returns(_fizzBuzzEvaluator)
                    .MustBeCalled();
                var fizzBuzzEngine = CreateFizzBuzzEngine();
                
                fizzBuzzEngine.Run(1, null);
                
                Mock.Assert(_fizzBuzzDefaultReplacements);
                Mock.Assert(_fizzBuzzEvaluatorFactory);
            }

            [Test]
            public void _Use_ReplacementsParameter_WhenInputReplacementsExists()
            {
                var defaultReplacement = new Replacement(2, "Hello");
                IList<Replacement> defaultReplacements = new List<Replacement> { defaultReplacement };
                Mock.Arrange(() => _fizzBuzzDefaultReplacements.Default)
                    .Returns(defaultReplacements).OccursNever();

                var parameterReplacement = new Replacement(2, "Hello");
                IList<Replacement> parameterReplacements = new List<Replacement> { parameterReplacement };

                Mock.Arrange(() => _fizzBuzzEvaluatorFactory
                    .Create(Arg.Matches<IList<Replacement>>(i => i.Count == 1 && Equals(i.First(), parameterReplacement))))
                    .Returns(_fizzBuzzEvaluator)
                    .MustBeCalled();
                var fizzBuzzEngine = CreateFizzBuzzEngine();

                fizzBuzzEngine.Run(1, parameterReplacements);

                Mock.Assert(_fizzBuzzDefaultReplacements);
                Mock.Assert(_fizzBuzzEvaluatorFactory);
            }

            private FizzBuzzEngine CreateFizzBuzzEngine()
            {
                var fizzBuzzEngine = new FizzBuzzEngine(_fizzBuzzEvaluatorFactory,
                    _output, _fizzBuzzDefaultReplacements);
                return fizzBuzzEngine;
            }


            private IFizzBuzzEvaluator CreateFizzBuzzEvaluator()
            {
                var fizzBuzzEvaluator = Mock.Create<IFizzBuzzEvaluator>();
                Mock.Arrange(() => _fizzBuzzEvaluatorFactory.Create(Arg.IsAny<IList<Replacement>>()))
                    .Returns(fizzBuzzEvaluator);
                return fizzBuzzEvaluator;
            }
        }
    }
}
