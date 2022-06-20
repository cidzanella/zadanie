using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class OperatorMultiply : IOperator
    {
        public double Process(double output, double number)
        {
            return output * number;
        }
    }
}
