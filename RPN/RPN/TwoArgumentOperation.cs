using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalulator
{
    public class TwoArgumentOperation
    {
        Dictionary<string, Func<int, int, int>> _operationFunction;
        public bool IsTwoArgumentOperation(String input) =>
            input.Equals("+") || input.Equals("-") ||
            input.Equals("*") || input.Equals("/");
        public int Operation(String op, int x, int y)
        {
            _operationFunction = new Dictionary<string, Func<int, int, int>>
            {
                ["+"] = (fst, snd) => (fst + snd),
                ["-"] = (fst, snd) => (fst - snd),
                ["*"] = (fst, snd) => (fst * snd),
                ["/"] = (fst, snd) => (fst / snd)
            };
            return _operationFunction[op](x, y);


        }
    }
}