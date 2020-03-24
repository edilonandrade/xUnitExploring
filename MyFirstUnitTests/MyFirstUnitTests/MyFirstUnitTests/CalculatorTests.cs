//https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyFirstUnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void CanAdd()
        {
            var calculator = new Calculator();

            int value1 = 1;
            int value2 = 2;

            var result = calculator.Add(value1, value2);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        public void CanAddTheory(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(CalCulatorTestData))]
        public  void CanAddTheoryClassData(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public void CanAddTheoryMemberDataMethod(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(CalculatorData.Data), MemberType = typeof(CalculatorData))]
        public void CanAddTheoryMemberDataMethod2(int value1, int value2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(value1, value2);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {1, 2, 3},
                new object[] {-4, -6, -10},
                new object[] {-2, 2, 0},
                new object[] {int.MinValue, -1, int.MaxValue}
            };

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] {1, 2, 3},
                new object[] {-4, -6, -10},
                new object[] {-2, 2, 0},
                new object[] {int.MinValue, -1, int.MaxValue}
            };

            return allData.Take(numTests);
        }
    }

    public class CalCulatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -4, -6, -10 };
            yield return new object[] { -2, 2, 0 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CalculatorData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {1, 2, 3},
                new object[] {-4, -6, -10},
                new object[] {-2, 2, 0},
                new object[] {int.MinValue, -1, int.MaxValue}
            };
    }
}
