using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Operators
    {
        public static Dictionary<string, IOperator> OperatorsDictionary { get; set; }

        public static void SetUpOperatorsDictionary()
        {
            if (OperatorsDictionary != null)
                return;

            OperatorsDictionary = new Dictionary<string, IOperator>();

            OperatorsDictionary.Add("add", new OperatorAdd());
            OperatorsDictionary.Add("subtract", new OperatorSubtract());
            OperatorsDictionary.Add("multiply", new OperatorMultiply());
            OperatorsDictionary.Add("divide", new OperatorDivide());
            OperatorsDictionary.Add("apply", new OperatorApply());
            OperatorsDictionary.Add("percent", new OperatorPercent());
        }

    }
}
