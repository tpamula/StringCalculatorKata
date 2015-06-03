using System;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("7", 7)]
        [InlineData("17", 17)]
        public void returns_correct_sum_for_one_number(string input, int expected)
        {
            var calculator = new StringCalculator();

            int result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void returns_zero_for_empty_string()
        {
            // arrange
            var calculator = new StringCalculator();

            // act
            int result = calculator.Add(string.Empty);

            // assert
            Assert.Equal(0, result);
        }
    }
}