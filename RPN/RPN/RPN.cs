using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using Microsoft.SqlServer.Server;

namespace RPNCalulator {
	public class RPN {
		private Stack<int> _operators;
		private OneArgumentOperation oneArgumentOperation = new OneArgumentOperation();
        private TwoArgumentOperation twoArgumentOperation = new TwoArgumentOperation();

        public int EvalRPN(string input) {
			_operators = new Stack<int>();

			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{
				if (oneArgumentOperation.IsNumber(op)) {
					_operators.Push(Int32.Parse(op));
				}
				else
				if(oneArgumentOperation.IsFactorial(op) && !_operators.IsEmpty) {
					int val = oneArgumentOperation.Factorial(_operators.Pop());
                    _operators.Push(val); 
                }
				else
				if (oneArgumentOperation.IsOtherNumberSystem(op)) {
					int val = oneArgumentOperation.ConvertToDecimal(op);
                    _operators.Push(val);
				}
				else
                if (twoArgumentOperation.IsTwoArgumentOperation(op)) {
					var num1 = _operators.Pop();
					var num2 = _operators.Pop();
					_operators.Push(twoArgumentOperation.Operation(op,num2,num1));
					//_operators.Push(Operation(op)(num1, num2));
				}
				else
                if (!oneArgumentOperation.IsNumber(op) || !oneArgumentOperation.IsFactorial(op) | !oneArgumentOperation.IsOtherNumberSystem(op) || !twoArgumentOperation.IsTwoArgumentOperation(op)) {
                    throw new InvalidOperationException();
                }
            }
			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException();
		}		
	}
}