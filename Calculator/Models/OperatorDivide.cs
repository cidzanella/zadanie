using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class OperatorDivide : IOperator
    {
        public double Process(double output, double number)
        {
            // check to avoid dividing by zero 
            if (number == 0)
                throw new Exception("Divide by zero error. Instruction 'divide 0' is not allowed.");

            return output / number;
        }
    }
}
