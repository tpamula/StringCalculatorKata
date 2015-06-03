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

            return input.Split(',').Sum(i => int.Parse(i));
        }
    }
}