using System;

namespace Calculator
{
    public class BootstrapperService
    {
        public double Output { get; set; }

        public void Initialize(string[] args)
        {
            // Validate instruction input file path
            if (args.Length == 0)
                throw new Exception("Calculator expects an Instructions Input file string path as an argument. \nEx: Calculator \"c:\\instructions.txt\"");

            // Initializes operators dictionary
            OperatorsFactory.OperatorsDictionary();

            // Generate instructions list from input file
            var instructions = new InstructionRepositoryService().GetInstructions(args[0]);

            // DI
            //var instructionRepository = new InstructionFileReader(args[0]);
            //var instructionProcessor = new InstructionProcessor(instructionRepository);
            // processor vai chamar repository.Getinstructions()
            //instructionsProcessor.Process();

            // Execute instructions
            Output = new InstructionProcessorService().Process(instructions);
            Console.WriteLine(Output);

        }
    }
}