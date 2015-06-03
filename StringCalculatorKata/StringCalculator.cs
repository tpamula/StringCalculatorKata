using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            int customDelimiterTagLength = @"//_\n".Length;
            var separators = new HashSet<char> { ',', '\n' };

            string inputWithoutCustomSeparatorTag = input;
            if (input.Length >= customDelimiterTagLength && input.Substring(0, 2) == "//")
            {
                separators.Add(input[2]);
                inputWithoutCustomSeparatorTag = input.Substring(customDelimiterTagLength - 1);
            }

            return inputWithoutCustomSeparatorTag.Split(separators.ToArray()).Sum(i => int.Parse(i));
        }
    }
}