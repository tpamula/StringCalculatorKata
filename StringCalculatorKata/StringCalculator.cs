using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            return string.IsNullOrEmpty(input)
                ? 0
                : input.Split(',').Sum(i => int.Parse(i));
        }
    }
}