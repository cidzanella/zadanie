using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // Receives a list of instructions, process it and return result
    public static class InstructionProcessor
    {
        public static double Process(List<Instruction> instructions)
        {
            // get the number associated with Apply operator
            double output = instructions.Last().Number;

            foreach (Instruction instruction in instructions)
            {
                switch (instruction.Operator)
                {
                    case Operators.Add:
                        output = output + instruction.Number;
                        break;
                    case Operators.Subtract:
                        output = output - instruction.Number;
                        break;
                    case Operators.Multiply:
                        output = output * instruction.Number;
                        break;
                    case Operators.Divide:
                        output = output / instruction.Number;
                        break;
                    case Operators.Apply:
                        break;
                    default:
                        throw new Exception("Wrong instruction operator found while processing instructions list.");
                }
            }
            return output;
        }
    }
}
