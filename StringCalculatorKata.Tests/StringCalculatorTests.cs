using System;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void handles_newline_as_delimiter()
        {
            var calculator = new StringCalculator();
            string input = "1\n2\n3";

            int result = calculator.Add(input);

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("4,1001,5", 9)]
        [InlineData("1001,1,1001", 1)]
        [InlineData("1001", 0)]
        public void ignores_numbers_bigger_than_1001(string input, int expected)
        {
            var calculator = new StringCalculator();

            int result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

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

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("7,5", 12)]
        [InlineData("10,3", 13)]
        public void returns_correct_sum_for_two_numbers(string input, int expected)
        {
            var calculator = new StringCalculator();

            int result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("10,20,30,40,50,60", 210)]
        [InlineData("7,8,9,10,11,12,13,14,15", 99)]
        public void returns_correct_sum_for_unknown_amount_of_numbers(string input, int expected)
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

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//c\n1c2c3", 6)]
        [InlineData("//!\n1!2!3!4", 10)]
        public void supports_custom_delimiters(string input, int expected)
        {
            var calculator = new StringCalculator();

            int result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[_ABcD\\]\n2_ABcD\\4_ABcD\\10", 16)]
        [InlineData("//[//]\n1//2//3//4", 10)]
        public void supports_custom_delimiters_of_any_length(string input, int expected)
        {
            var calculator = new StringCalculator();

            int result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-2", "-2")]
        [InlineData("1,2,3,-4,-5", "-4,-5")]
        [InlineData("1,2,3,-4,-5,1,1,-3,2", "-4,-5,-3")]
        public void throws_exception_with_negative_numbers_in_input(string input, string expected)
        {
            var calculator = new StringCalculator();

            Action processInput = () => calculator.Add(input);

            var exception = Assert.Throws<Exception>(processInput);
            Assert.Equal(expected, exception.Message);
        }
    }
}