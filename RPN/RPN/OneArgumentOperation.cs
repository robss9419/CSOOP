using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalulator
{
    internal class OneArgumentOperation
    {
        public bool IsNumber(String input) => Int32.TryParse(input, out _);
        public bool IsFactorial(String input) => (input == "!");

        public bool IsOtherNumberSystem(String input) =>
            input[0] == 'B' || input[0] == 'D' ||
            input[0] == '#';
        public int ConvertToDecimal(String input)
        {
            if (input[0] == 'B') {
                int decimalVal = Convert.ToInt32(input.ToString().Substring(1), 2);
                return decimalVal;
            }
            else
            if (input[0] == 'D') {
                int decimalVal = Int32.Parse(input.Substring(1));
                return decimalVal;
            }
            else {
                int decimalVal = Convert.ToInt32(input.ToString().Substring(1), 16);
                return decimalVal;
            }
        }
        public int Factorial(int num1)
        {
            int score = 1;
            for (int i = 1; i <= num1; i++)
            {
                score = i * score;
            }
            return score;
        }
    }
}
