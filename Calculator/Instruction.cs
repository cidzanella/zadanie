using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    //public enum Operators
    //{
    //    Add, Subtract, Multiply, Divide, Apply
    //}
    public class Instruction : IInstruction
    {
        public IOperator Operator { get; set; }
        public double Number { get; set; }

        public Instruction(string operation, string number)
        {
            // validates number parameter
            if (!double.TryParse(number, out double doubleNumber))
            {
                throw new Exception($"'{number}' is not a valid number for Instruction.");
            }
            this.Number = doubleNumber;

            // select operator classfrom strategy dictionary
            try
            {
                this.Operator = Operators.OperatorsDictionary[operation];
            }
            catch (Exception)
            {
                throw new Exception($"'{operation}' is not a valid operator for Instruction.");
            }
       }
   }
}
