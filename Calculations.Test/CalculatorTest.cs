using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Test
{
    public class CalculatorFixture:IDisposable
    {
        public Calculator Calc => new Calculator();
        public void Dispose()
        {
            //Clean
        }
    }
    public class CalculatorTest : IClassFixture<CalculatorFixture>,IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream memoryStream;
        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
            _testOutputHelper.WriteLine("Constructor");
            memoryStream = new MemoryStream();
        }
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.Add(1, 2);
            Assert.Equal(3,result);
        }
        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.AddDouble(1.23, 3.55);
            Assert.Equal(4.7,result, 0);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("FiboDoesNotIncludeZero");
            var calc = _calculatorFixture.Calc;
            Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboIncludes13()
        {
            _testOutputHelper.WriteLine("FiboIncludes13");
            var calc = _calculatorFixture.Calc;
            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotContain4()
        {
            _testOutputHelper.WriteLine("FiboDoesNotContain4");
            var calc = _calculatorFixture.Calc;
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine("CheckCollection");
            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };
            var calc = _calculatorFixture.Calc;
            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        [Fact]
        public void isOdd_GivenOddValue_ReturnsTrue()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.isOdd(1);
            Assert.True(result);
        }


        [Fact]
        public void isOdd_GivenEvenValue_ReturnsFalse()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.isOdd(2);
            Assert.False(result);
        }

        [Theory]
        //[MemberData(nameof(TestDataShare.isOddOrEvenExternalData),MemberType=typeof(TestDataShare))]
        [isOddOrEvenData]
        public void isOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.isOdd(value);
            Assert.True(result);
        }
        public void Dispose()
        {
            memoryStream.Close();
        }
    }
}
