using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
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