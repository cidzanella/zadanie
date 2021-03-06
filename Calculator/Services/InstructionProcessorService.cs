using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // Receives a list of instructions, process it and return result
    public class InstructionProcessorService : IInstructionProcessor
    {
        public double Process(ICollection<IInstruction> instructions)
        {
            // get the number associated with Apply operator
            double output = instructions.Last().Number;

            foreach (Instruction instruction in instructions)
                output = instruction.Operator.Process(output, instruction.Number);

            return output;
        }
    }
}
