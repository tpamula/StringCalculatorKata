using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            HashSet<string> delimiters = GetDelimiters(input);

            string inputWithoutCustomDelimiterTag = GetInputWithoutCustomDelimiterTag(input);

            var numbers = inputWithoutCustomDelimiterTag
                                .Split(delimiters.ToArray(), StringSplitOptions.None)
                                .Select(int.Parse)
                                .Where(i => i < 1001)
                                .ToList();

            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Any()) throw new Exception(string.Join(",", negatives));

            return numbers.Sum();
        }

        private HashSet<string> GetDelimiters(string input)
        {
            int customOneCharDelimiterLength = "//_\n".Length;
            var delimiters = new HashSet<string> { ",", "\n" };

            if (input.Length < customOneCharDelimiterLength
                || input.Substring(0, 2) != "//") return delimiters;

            switch (input[2])
            {
                case '[':
                    int closingBracketIndex = input.IndexOf("]");
                    string delimiter = input.Substring(3, closingBracketIndex - 3);

                    delimiters.Add(delimiter);
                    break;

                default:

                    if (input.Length >= customOneCharDelimiterLength)
                    {
                        delimiters.Add(input[2].ToString());
                    }
                    break;
            }

            return delimiters;
        }

        private string GetInputWithoutCustomDelimiterTag(string input)
        {
            int customOneCharDelimiterLength = "//_\n".Length;

            if (input.Length < customOneCharDelimiterLength
                || input.Substring(0, 2) != "//") return input;

            if (input[2] == '[')
            {
                int closingBracketIndex = input.IndexOf(']');
                return input.Substring(closingBracketIndex + 2);
            }
            else
            {
                return input.Substring(customOneCharDelimiterLength);
            }
        }
    }
}