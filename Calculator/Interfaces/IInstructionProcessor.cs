using System.Collections.Generic;

namespace Calculator
{
    public interface IInstructionProcessor
    {
        double Process(ICollection<IInstruction> instructions);
    }
}