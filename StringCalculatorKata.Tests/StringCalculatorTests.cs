using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void handles_newline_as_separator()
        {
            var calculator = new StringCalculator();
            string input = "1\n2\n3";

            int result = calculator.Add(input);

            Assert.Equal(6, result);
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
    }
}