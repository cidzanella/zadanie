using System.Collections.Generic;

namespace Calculator
{
    public interface IInstructionRepository
    {
        ICollection<IInstruction> GetInstructions(string respositoryDirection);
    }
}