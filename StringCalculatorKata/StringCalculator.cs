using System;
using System.Collections.Generic;
using System.Linq;

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
                    int closingBracketIndex = input.IndexOf("]", StringComparison.Ordinal);
                    int openingBracketIndex = 3;

                    string delimiter = input.Substring(openingBracketIndex, closingBracketIndex - 3);
                    delimiters.Add(delimiter);

                    openingBracketIndex = input.IndexOf("[", openingBracketIndex + 1,
                        StringComparison.Ordinal);
                    closingBracketIndex = input.IndexOf("]", closingBracketIndex + 1,
                            StringComparison.Ordinal);
                    while (openingBracketIndex != -1)
                    {
                        delimiter = input.Substring(openingBracketIndex + 1,
                            closingBracketIndex - openingBracketIndex - 1);
                        delimiters.Add(delimiter);

                        openingBracketIndex = input.IndexOf("[", openingBracketIndex + 1,
                            StringComparison.Ordinal);
                        closingBracketIndex = input.IndexOf("]", closingBracketIndex + 1,
                            StringComparison.Ordinal);
                    }

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
                int closingBracketIndex = input.LastIndexOf(']');
                return input.Substring(closingBracketIndex + 2);
            }
            else
            {
                return input.Substring(customOneCharDelimiterLength);
            }
        }
    }
}