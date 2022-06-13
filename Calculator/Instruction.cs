using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum Operators
    {
        Add, Subtract, Multiply, Divide, Apply
    }
    public class Instruction
    {
        public Operators Operator { get; set; }
        public double Number { get; set; }

        public Instruction(string calcOperator, string number)
        {
            if (!double.TryParse(number, out double doubleNumber))
            {
                throw new ArgumentException($"'{number}' is not a valid number for Instruction.");
            }
            this.Number = doubleNumber;

            switch (calcOperator.ToLower())
            {
                case "add":
                    this.Operator = Operators.Add;
                    break;
                case "subtract":
                    this.Operator = Operators.Subtract;
                    break;
                case "multiply":
                    this.Operator = Operators.Multiply;
                    break;
                case "divide":
                    this.Operator = Operators.Divide;
                    break;
                case "apply":
                    this.Operator = Operators.Apply;
                    break;
                default:
                    throw new ArgumentException($"Operator '{calcOperator}' not recognized on instruction.");
            }
        }
    }
}
