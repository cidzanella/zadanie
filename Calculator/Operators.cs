using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Operators
    {
        private static Dictionary<string, IOperator> _operatorsDictionary;
        
        public static Dictionary<string, IOperator> OperatorsDictionary()
        {
            if (_operatorsDictionary != null)
                return _operatorsDictionary;

            return SetUpOperatorsDictionary();
        }      

        private static Dictionary<string, IOperator> SetUpOperatorsDictionary()
        {
            _operatorsDictionary = new Dictionary<string, IOperator>();

            _operatorsDictionary.Add("add", new OperatorAdd());
            _operatorsDictionary.Add("subtract", new OperatorSubtract());
            _operatorsDictionary.Add("multiply", new OperatorMultiply());
            _operatorsDictionary.Add("divide", new OperatorDivide());
            _operatorsDictionary.Add("apply", new OperatorApply());
            _operatorsDictionary.Add("percent", new OperatorPercent());

            return _operatorsDictionary;
        }
        public static IOperator GetOperatorFromDictionary(string operation)
        {
            return _operatorsDictionary[operation];
        }
    }
}
