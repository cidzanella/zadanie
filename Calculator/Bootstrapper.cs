using System;

namespace Calculator
{
    public class Bootstrapper
    {
        public double Output { get; set; }

        public void Initialize(string[] args)
        {
            // Validate instruction input file path
            if (args.Length == 0)
                throw new Exception("Calculator expects an Instructions Input file string path as an argument. \nEx: Calculator \"c:\\instructions.txt\"");

            // Initializes operators dictionary
            Operators.OperatorsDictionary();

            // Generate instructions list from input file
            var instructions = InstructionFileReader.GetInstructions(args[0]);

            // Execute instructions
            Output = InstructionProcessor.Process(instructions);
            Console.WriteLine(Output);

        }
    }
}