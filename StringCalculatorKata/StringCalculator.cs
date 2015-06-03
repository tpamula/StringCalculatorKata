using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            char[] separators = { ',', '\n' };

            return string.IsNullOrEmpty(input)
                ? 0
                : input.Split(separators).Sum(i => int.Parse(i));
        }
    }
}